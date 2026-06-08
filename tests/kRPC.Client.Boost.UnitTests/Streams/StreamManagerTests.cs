using System.Linq.Expressions;
using AutoFixture;
using kRPC.Client.Boost.Config;
using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Helpers;
using kRPC.Client.Boost.Services.KRPC.RemoteObjects;
using kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;
using kRPC.Client.Boost.Streams;
using kRPC.Client.Boost.UnitTests.Helpers;
using NSubstitute;
using NSubstitute.ClearExtensions;

namespace kRPC.Client.Boost.UnitTests.Streams;

// StreamManager tests have to run with parallelisation disabled so they don't share conflicting static state
[Collection(nameof(StreamManagerTests))]
public class StreamManagerTests
{
    private readonly Fixture _fixture = new();
    private readonly StreamConfig _config = new();

    private readonly IConnectionMultiplexer _connection;
    private readonly ulong _remoteStreamId;
    
    private const string InsideLockOperationId = "CompactDictionaries.InsideLock";

    public StreamManagerTests()
    {
        _connection = Substitute.For<IConnectionMultiplexer>();
        _remoteStreamId = _fixture.Create<ulong>();

        var remoteStream = new RemoteStream(_connection, _remoteStreamId);
        _connection.AddStream(Arg.Any<Expression<Func<string>>>(), Arg.Any<bool>())
            .Returns(remoteStream);
    }

    [Fact]
    public async Task Initialise_OnlyInitialisesOnce_WhenCalledMultipleTimes()
    {
        // Arrange
        StreamManager.Reset();
        var initEvent = new ManualResetEventSlim(false);
        var continueEvent = new ManualResetEventSlim(false);
        var injector = InjectorHelper.GetInjector();
        injector.ClearSubstitute();
        injector
            .When(x => x.DoWork(nameof(StreamManager.Initialise)))
            .Do(_ =>
            {
                initEvent.Set();
                continueEvent.Wait();
            });

        // Act
        var initTaskA = Task.Run(() => StreamManager.Initialise(_connection, _config));
        initEvent.Wait();
        var initTaskB = Task.Run(() => StreamManager.Initialise(_connection, _config));
        continueEvent.Set();
        await initTaskA;
        await initTaskB;

        // Assert
        injector.Received(1).DoWork(nameof(StreamManager.Initialise));
    }

    [Fact]
    public void AddSubscription_ThrowsException_WhenNotInitialised()
    {
        StreamManager.Reset();
        var key = _fixture.Create<string>();
        var expressionReturn = _fixture.Create<string>();
        Assert.Throws<InvalidOperationException>(() => StreamManager.AddSubscription(key, () => expressionReturn));
    }

    [Fact]
    public void RemoveSubscription_ThrowsException_WhenUninitialised()
    {
        StreamManager.Reset();
        var key = _fixture.Create<string>();
        Assert.Throws<InvalidOperationException>(() => StreamManager.RemoveSubscription(key));
    }

    [Fact]
    public void TryGet_ThrowsException_WhenUninitialised()
    {
        StreamManager.Reset();
        var key = _fixture.Create<string>();
        Assert.Throws<InvalidOperationException>(() => StreamManager.TryGet<string>(key, out _));
    }

    [Fact]
    public void SetValue_ThrowsException_WhenUninitialised()
    {
        StreamManager.Reset();
        var key = _fixture.Create<ulong>();
        var value = _fixture.Create<string>();
        Assert.Throws<InvalidOperationException>(() => StreamManager.SetValue(key, value));
    }

    [Fact]
    public void AddSubscription_InitialisesStream_IfStreamDoesntExist()
    {
        // Arrange
        StreamManager.Reset();
        var key = _fixture.Create<string>();
        var value = _fixture.Create<string>();
        Expression<Func<string>> expression = () => value;
        StreamManager.Initialise(_connection, _config);

        // Act
        StreamManager.AddSubscription(key, expression);

        // Assert
        _connection.Received(1).AddStream(expression, true);
    }

    [Fact]
    public async Task AddSubscription_DoesntReinitialiseStream_IfStreamAlreadyHadSubscribers()
    {
        // Arrange
        StreamManager.Reset();
        var initEvent = new ManualResetEventSlim(false);
        var continueEvent = new ManualResetEventSlim(false);
        var key = _fixture.Create<string>();
        var value = _fixture.Create<string>();
        Expression<Func<string>> expression = () => value;
        StreamManager.Initialise(_connection, _config);

        _connection
            .When(x =>
                x.AddStream(
                    Arg.Is<Expression<Func<string>>>(x => x.Compile().Invoke() == value),
                    true))
            .Do(_ =>
            {
                initEvent.Set();
                continueEvent.Wait();
            });

        // Act
        var addTaskA = Task.Run(() => StreamManager.AddSubscription(key, expression));
        initEvent.Wait();
        var addTaskB = Task.Run(() => StreamManager.AddSubscription(key, expression));
        continueEvent.Set();
        await Task.WhenAll(addTaskA, addTaskB);

        // Assert
        _connection.Received(1).AddStream(expression, true);
    }

    [Fact]
    public void AddSubscription_InitialisesStream_IfStreamHasNoSubscribers()
    {
        // Arrange
        StreamManager.Reset();
        var key = _fixture.Create<string>();
        var value = _fixture.Create<string>();
        Expression<Func<string>> expression = () => value;
        StreamManager.Initialise(_connection, _config);
        StreamManager.AddSubscription(key, expression);
        StreamManager.RemoveSubscription(key);
        _connection.ClearReceivedCalls();

        // Act
        StreamManager.AddSubscription(key, expression);

        // Assert
        _connection.Received(1).AddStream(expression, true);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 0)]
    public void RemoveSubscription_TakesCorrectAction_DependingOnNumberOfSubscribers(
        int numberOfSubscribers, int expectedNumRemoveCalls)
    {
        // Arrange
        StreamManager.Reset();
        var key = _fixture.Create<string>();
        var value = _fixture.Create<string>();
        Expression<Func<string>> expression = () => value;
        StreamManager.Initialise(_connection, _config);
        for (var i = 0; i < numberOfSubscribers; i++)
            StreamManager.AddSubscription(key, expression);
        _connection.ClearReceivedCalls();

        // Act
        StreamManager.RemoveSubscription(key);

        // Assert
        _connection.Received(expectedNumRemoveCalls).RemoveStream(_remoteStreamId);
    }

    [Fact]
    public void TryGet_ReturnsFalse_IfStreamDoesntExist()
    {
        // Arrange
        StreamManager.Reset();
        var key = _fixture.Create<string>();
        StreamManager.Initialise(_connection, _config);

        // Act
        var result = StreamManager.TryGet<string>(key, out _);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void TryGet_ReturnsFalse_IfStreamHasNoSubscribers()
    {
        // Arrange
        StreamManager.Reset();
        var key = _fixture.Create<string>();
        var value = _fixture.Create<string>();
        Expression<Func<string>> expression = () => value;
        StreamManager.Initialise(_connection, _config);
        StreamManager.AddSubscription(key, expression);
        StreamManager.RemoveSubscription(key);

        // Act
        var result = StreamManager.TryGet<string>(key, out _);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void TryGet_ThrowsException_IfRequestedDataTypeDoesntMatchStream()
    {
        // Arrange
        StreamManager.Reset();
        var key = _fixture.Create<string>();
        var value = _fixture.Create<string>();
        Expression<Func<string>> expression = () => value;
        StreamManager.Initialise(_connection, _config);
        StreamManager.AddSubscription(key, expression);
        StreamManager.RemoveSubscription(key);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => StreamManager.TryGet<int>(key, out _));
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void TryGet_GetsCorrectValue_WhenSetByTrySet(bool nullValue)
    {
        // Arrange
        StreamManager.Reset();
        var key = _fixture.Create<string>();
        var value = nullValue ? null : _fixture.Create<string>();
        Expression<Func<string?>> expression = () => value;
        StreamManager.Initialise(_connection, _config);
        StreamManager.AddSubscription(key, expression);

        // Act
        StreamManager.SetValue(_remoteStreamId, value);
        var result = StreamManager.TryGet<string>(key, out var storedValue);

        // Assert
        Assert.True(result);
        Assert.Equal(value, storedValue);
    }

    [Fact]
    public void TrySet_ThrowsException_IfValueHasDifferentDataTypeToStream()
    {
        // Arrange
        StreamManager.Reset();
        var key = _fixture.Create<string>();
        var value = _fixture.Create<string>();
        Expression<Func<string>> expression = () => value;
        StreamManager.Initialise(_connection, _config);
        StreamManager.AddSubscription(key, expression);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => StreamManager.SetValue(_remoteStreamId, RemoteObjectFixture.Create<Vessel>()));
    }
    
    [Fact]
    public void TrySet_DoesntThrow_IfStreamDoesntExist()
    {
        // Arrange
        StreamManager.Reset();
        StreamManager.Initialise(_connection, _config);

        // Act & Assert
        StreamManager.SetValue(_remoteStreamId, "");
    }
    
    [Fact]
    public void TrySet_DoesntThrow_IfStreamHasNoSubscribers()
    {
        // Arrange
        StreamManager.Reset();
        var key = _fixture.Create<string>();
        var value = _fixture.Create<string>();
        Expression<Func<string>> expression = () => value;
        StreamManager.Initialise(_connection, _config);
        StreamManager.AddSubscription(key, expression);
        StreamManager.RemoveSubscription(key);

        // Act & Assert
        StreamManager.SetValue(_remoteStreamId, "");
    }

    [Fact]
    public void CompactionLoop_DoesntDoAnything_IfDictionariesHaventBreachedMaxSize()
    {
        // Arrange
        var context = SetupCompactionTest(10);
        
        // Act
        StreamManager.Initialise(_connection, _config);
        context.StartEvent.Set();
        context.EndEvent.Wait();
        context.CompletionToken.Cancel();
        StreamManager.Reset();

        // Assert
        Assert.Equal(context.InitialSize, context.FinalSize);
        Assert.Equal(context.InitialMaxSize, context.FinalMaxSize);
        context.Injector.Received(0).DoWork(InsideLockOperationId, Arg.Any<Dictionary<string,object>>());
    }

    [Fact]
    public void CompactionLoop_RemovesEntriesWithNoSubscribers()
    {
        // Arrange
        var context = SetupCompactionTest(1);
        var keyA = _fixture.Create<string>();
        var keyB = _fixture.Create<string>();
        var value = _fixture.Create<string>();
        Expression<Func<string>> expression = () => value;
        
        // Act
        StreamManager.Initialise(_connection, _config);
        StreamManager.AddSubscription(keyA, expression);
        StreamManager.AddSubscription(keyB, expression);
        StreamManager.RemoveSubscription(keyA);
        StreamManager.RemoveSubscription(keyB);
        context.StartEvent.Set();
        context.EndEvent.Wait();
        context.CompletionToken.Cancel();
        StreamManager.Reset();
        
        // Assert
        Assert.Equal(2, context.InitialSize);
        Assert.Equal(0, context.FinalSize);
        context.Injector.Received(1).DoWork(InsideLockOperationId, Arg.Any<Dictionary<string,object>>());
    }
    
    [Theory]
    [InlineData(10, 2)]
    [InlineData(1, 1)]
    public void CompactionLoop_TakesCorrectExpansionAction_BasedOnMaxSizeConfig(
        int maxMaxSize,
        int expectedFinalMaxSize)
    {
        // Arrange
        var context = SetupCompactionTest(1, 1, maxMaxSize);
        var value = _fixture.Create<string>();
        Expression<Func<string>> expression = () => value;
        
        // Act
        StreamManager.Initialise(_connection, _config);
        StreamManager.AddSubscription(_fixture.Create<string>(), expression);
        StreamManager.AddSubscription(_fixture.Create<string>(), expression);
        context.StartEvent.Set();
        context.EndEvent.Wait();
        context.CompletionToken.Cancel();
        StreamManager.Reset();
        
        // Assert
        Assert.Equal(2, context.InitialSize);
        Assert.Equal(1, context.InitialMaxSize);
        Assert.Equal(2, context.FinalSize);
        Assert.Equal(expectedFinalMaxSize, context.FinalMaxSize);
        context.Injector.Received(1).DoWork(InsideLockOperationId, Arg.Any<Dictionary<string,object>>());
    }

    private CompactionTestContext SetupCompactionTest(int initialMaxSize, 
        int? sizeIncreaseInterval = null,
        int? maxMaxSize = null)
    {
        StreamManager.Reset();
        const string size = "NumEntries";
        const string maxSize = "MaxSize";
        const string start = "CompactDictionaries.Start";
        const string hold = "CompactDictionaries.Hold";
        const string end = "CompactDictionaries.End";
        
        // Variables
        var injector = InjectorHelper.GetInjector();
        injector.ClearSubstitute();
        var context = new CompactionTestContext
        {
            InitialSize = 0,
            InitialMaxSize = 0,
            FinalSize = 0,
            FinalMaxSize = 0,
            StartEvent = new AutoResetEvent(false),
            EndEvent = new ManualResetEventSlim(),
            Injector = injector,
            CompletionToken = new CancellationTokenSource()
        };
        
        // Injector config
        injector
            .When(x => x.DoWork(hold, 
                Arg.Any<Dictionary<string,object>>()))
            .Do(x =>
            {
                // Wait until we're given the signal to start another compaction cycle or
                // we're told that the test is complete and the compaction thread can be killed
                WaitHandle.WaitAny(
                [
                    context.StartEvent,
                    context.CompletionToken.Token.WaitHandle
                ]);

                if (context.CompletionToken.IsCancellationRequested)
                    throw new OperationCanceledException();
            });
        injector
            .When(x => x.DoWork(start, 
                Arg.Any<Dictionary<string,object>>()))
            .Do(x =>
            {
                var args = x.Arg<Dictionary<string,object>?>();
                context.InitialSize = (int)args![size];
                context.InitialMaxSize = (int)args![maxSize];
            });
        injector
            .When(x => x.DoWork(end, 
                Arg.Any<Dictionary<string,object>>()))
            .Do(x =>
            {
                var args = x.Arg<Dictionary<string,object>?>();
                context.FinalSize = (int)args![size];
                context.FinalMaxSize = (int)args![maxSize];
                context.EndEvent.Set();
            });
        
        // Stream manager config
        _config.CompactionInterval = TimeSpan.FromMicroseconds(100); // We want it to fire almost immediately
        _config.InitialDictionarySize = initialMaxSize;
        _config.MaxDictionarySizeIncreaseInterval = sizeIncreaseInterval ?? _config.MaxDictionarySizeIncreaseInterval;
        _config.MaxDictionarySize = maxMaxSize ?? _config.MaxDictionarySize;

        return context;
    }
}

[CollectionDefinition(nameof(StreamManagerTests), DisableParallelization = true)]
public sealed class StreamManagerTestCollection
{
}

internal class CompactionTestContext
{
    public required int InitialSize;
    public required int InitialMaxSize;
    public required int FinalSize;
    public required int FinalMaxSize;
    public required AutoResetEvent StartEvent;
    public required ManualResetEventSlim EndEvent;
    public required CancellationTokenSource CompletionToken;
    public required IMethodInjector Injector;
}