using System.Linq.Expressions;
using AutoFixture;
using kRPC.Client.Boost.Config;
using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Helpers;
using kRPC.Client.Boost.Services.KRPC.RemoteObjects;
using kRPC.Client.Boost.Streams;
using NSubstitute;

namespace kRPC.Client.Boost.UnitTests.Streams;

[Collection(nameof(StreamManagerTests))]
public class StreamManagerTests
{
    private readonly Fixture _fixture = new();
    private readonly StreamConfig _config = new();

    private readonly IConnectionMultiplexer _connection;
    private readonly ulong _remoteStreamId;

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
        var operationId = _fixture.Create<string>();
        var methodInjector = Substitute.For<IMethodInjector>();
        methodInjector
            .When(x => x.DoWork(operationId))
            .Do(_ =>
            {
                initEvent.Set();
                continueEvent.Wait();
            });
        StaticMethodInjector.MethodInjector = methodInjector;
        
        // Act
        var initTaskA = Task.Run(() => StreamManager.Initialise(_connection, _config, operationId));
        initEvent.Wait();
        var initTaskB = Task.Run(() => StreamManager.Initialise(_connection, _config, operationId));
        continueEvent.Set();
        await initTaskA;
        await initTaskB;
        
        // Assert
        methodInjector.Received(1).DoWork(operationId);
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
        
        // Act
        StreamManager.AddSubscription(key, expression);

        // Assert
        _connection.Received(1).AddStream(expression, true);
    }
}

[CollectionDefinition(nameof(StreamManagerTests),  DisableParallelization = true)]
public sealed class StreamManagerTestCollection
{
}
