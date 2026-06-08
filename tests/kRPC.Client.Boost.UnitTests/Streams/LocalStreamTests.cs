using System.Linq.Expressions;
using AutoFixture;
using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Helpers;
using kRPC.Client.Boost.Services.KRPC.RemoteObjects;
using kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;
using kRPC.Client.Boost.Streams;
using NSubstitute;

namespace kRPC.Client.Boost.UnitTests.Streams;

public class LocalStreamTests
{
    private Fixture _fixture;
    private RemoteStream _remoteStream = null!;
    private IConnectionMultiplexer _connection;
    private Expression<Func<string>> _expression;

    public LocalStreamTests()
    {
        _fixture = new Fixture();
        _connection = Substitute.For<IConnectionMultiplexer>();
        
        var streamId = _fixture.Create<ulong>();
        SetRemoteStreamId(streamId);
        
        var vessel = new Vessel(_connection, 1);
        _expression = () => vessel.GetBiome();
    }
    
    [Fact]
    public void AddsStream_OnCreation()
    {
        // Act
        var localStream = new LocalStream<string>(_connection, _expression);
        
        // Assert
        Assert.Equal(_remoteStream.Id, localStream.RemoteId);
        _connection.Received().AddStream(_expression, true);
    }

    [Fact]
    public void RemovesStream_OnTearDown()
    {
        // Arrange
        var localStream = new LocalStream<string>(_connection, _expression);
        
        // Act
        localStream.TearDown();
        
        // Assert
        _connection.Received().RemoveStream(_remoteStream.Id);
    }

    [Fact]
    public void ReAddsStream_OnReInitialise()
    {
        // Arrange
        var localStream = new LocalStream<string>(_connection, _expression);
        var originalRemoteId = _remoteStream.Id;
        var originalLocalId = localStream.RemoteId;
        var newStreamId = _fixture.Create<ulong>();
        SetRemoteStreamId(newStreamId);
        localStream.TearDown();
        
        // Act
        localStream.InitialiseStream();
        
        // Assert
        Assert.NotEqual(originalRemoteId, _remoteStream.Id);
        Assert.NotEqual(originalLocalId, localStream.RemoteId);
        Assert.Equal(_remoteStream.Id, localStream.RemoteId);
        _connection.Received().AddStream(_expression, true);
    }

    [Fact]
    public void ReturnsTrue_WhenSettingValueOnInitialisedStream()
    {
        // Arrange
        var localStream = new LocalStream<string>(_connection, _expression);
        var newValue = _fixture.Create<string>();
        
        // Act
        var result = localStream.TrySet(newValue);
        
        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void ReturnsFalse_WhenSettingValueOnUninitialisedStream()
    {
        // Arrange
        var localStream = new LocalStream<string>(_connection, _expression);
        var newValue = _fixture.Create<string>();
        localStream.TearDown();
        
        // Act
        var result = localStream.TrySet(newValue);
        
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void ThrowsArgumentException_WhenSettingValueOfWrongType()
    {
        // Arrange
        var localStream = new LocalStream<string>(_connection, _expression);
        var newValue = _fixture.Create<int>();
        
        // Act & Assert
        Assert.Throws<ArgumentException>(() => localStream.TrySet(newValue));
    }
    
    [Fact]
    public void ReturnsCorrectValue_WhenGettingCurrentValue()
    {
        // Arrange
        var localStream = new LocalStream<string>(_connection, _expression);
        var newValue = _fixture.Create<string>();
        localStream.TrySet(newValue);
        
        // Act
        var result = localStream.TryGet(out var value);
        
        // Assert
        Assert.True(result);
        Assert.Equal(newValue, value);
    }

    [Fact]
    public void ThrowsArgumentException_WhenGettingValueOfWrongType()
    {
        // Arrange
        var localStream = new LocalStream<string>(_connection, _expression);
        var newValue = _fixture.Create<string>();
        localStream.TrySet(newValue);
        
        // Act & Assert
        Assert.Throws<ArgumentException>(() => localStream.TryGet<int>(out _));
    }

    [Theory]
    [InlineData(0, true)]
    [InlineData(1, false)]
    public void ReturnsCorrectly_WhenAddingSubscriber(int numPreExistingSubscribers, bool expectedResult)
    {
        // Arrange
        var localStream = new LocalStream<string>(_connection, _expression);
        localStream.RemoveSubscriber(); // Streams start with 1, this is the easiest way to set up the test
        for (var i = 0; i < numPreExistingSubscribers; i++)
            localStream.AddSubscriber();
        
        // Act
        var result = localStream.AddSubscriber();
        
        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(1, false)]
    [InlineData(2, true)]
    public void ReturnsCorrectly_WhenRemovingSubscriber(int numPreExistingSubscribers, bool expectedResult)
    {
        // Arrange
        var localStream = new LocalStream<string>(_connection, _expression);
        for (var i = 1; i < numPreExistingSubscribers; i++)
            localStream.AddSubscriber();
        
        // Act
        var result = localStream.RemoveSubscriber();
        
        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void ThrowsException_WhenRemovingSubscriberFromStreamWithNoSubscribers()
    {
        // Arrange
        var localStream = new LocalStream<string>(_connection, _expression);
        localStream.RemoveSubscriber();
        
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => localStream.RemoveSubscriber());
    }

    [Theory]
    [InlineData(true, true, true)]
    [InlineData(true, false, true)]
    [InlineData(false, true, false)]
    [InlineData(false, false, false)]
    public async Task WaitsForInitOrTearDown_WhenGettingOrSettingValues(bool isInit, bool isSet, bool expectedResult)
    {
        // Arrange
        var initEvent = new ManualResetEventSlim(false);
        var continueEvent = new ManualResetEventSlim(false);
        var localStream = new LocalStream<string>(_connection, _expression);
        if (isInit)
            localStream.TearDown();
        Action<IConnectionMultiplexer> method = isInit 
            ? x => x.AddStream(Arg.Any<Expression<Func<string>>>(), Arg.Any<bool>())
            : x => x.RemoveStream(Arg.Any<ulong>());
        _connection
            .When(method)
            .Do(x =>
            {
                initEvent.Set();
                continueEvent.Wait();
            });
        
        // Act
        var initTask = isInit 
            ? Task.Run(() => localStream.InitialiseStream())
            : Task.Run(() => localStream.TearDown());
        initEvent.Wait(); // Wait for the initialisation to be in progress
        var getOrSetTask = isSet
            ? Task.Run(() => localStream.TrySet(_fixture.Create<string>()))
            : Task.Run(() => localStream.TryGet(out _));
        
        // Assert
        Assert.False(initTask.IsCompleted); // Both should be in a deadlock initially
        Assert.False(getOrSetTask.IsCompleted);

        continueEvent.Set(); // Let the init/teardown finish
        await initTask;
        var result = await getOrSetTask;
        Assert.True(initTask.IsCompleted);
        Assert.True(getOrSetTask.IsCompleted);
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task WaitsForGetOrSet_WhenTearingDownStream(bool isSet)
    {
        // Arrange
        var initEvent = new ManualResetEventSlim(false);
        var continueEvent = new ManualResetEventSlim(false);
        var localStream = new LocalStream<string>(_connection, _expression);
        var injector = Substitute.For<IMethodInjector>();
        injector
            .When(x => x.DoWork(localStream.RemoteId))
            .Do(x =>
            {
                initEvent.Set();
                continueEvent.Wait();
            });
        StaticMethodInjector.MethodInjector = injector;
        
        // Act
        var getOrSetTaskA = isSet 
            ? Task.Run(() => localStream.TrySet(_fixture.Create<string>()))
            : Task.Run(() => localStream.TryGet(out _));
        initEvent.Wait(); // Wait for the set/get to be in progress
        var teardownTask = Task.Run(() => localStream.TearDown());
        // Wait for the teardown thead to hit the write lock
        SpinWait.SpinUntil(() => localStream.NumInitLockWriteWaiters > 0);
        var getOrSetTaskB = isSet
            ? Task.Run(() => localStream.TrySet(_fixture.Create<string>()))
            : Task.Run(() => localStream.TryGet(out _));
        
        // Assert
        Assert.False(teardownTask.IsCompleted); // All should be in a deadlock initially
        Assert.False(getOrSetTaskA.IsCompleted);
        Assert.False(getOrSetTaskB.IsCompleted);

        continueEvent.Set(); // Let the get/set finish
        await teardownTask;
        var resultA = await getOrSetTaskA;
        var resultB = await getOrSetTaskB;
        Assert.True(teardownTask.IsCompleted);
        Assert.True(getOrSetTaskA.IsCompleted);
        Assert.True(getOrSetTaskB.IsCompleted);
        Assert.True(resultA);
        Assert.False(resultB);
    }
    
    private void SetRemoteStreamId(ulong id)
    {
        _remoteStream = new RemoteStream(_connection, id);
        _connection.AddStream(Arg.Any<Expression<Func<string>>>(), Arg.Any<bool>())
            .Returns(_remoteStream);
    }
}
