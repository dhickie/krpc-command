using AutoFixture;
using kRPC.Client.Boost.Config;
using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Helpers;
using kRPC.Client.Boost.Streams;
using NSubstitute;

namespace kRPC.Client.Boost.UnitTests.Streams;

public class StreamManagerTests
{
    private readonly Fixture _fixture = new();
    private readonly IConnectionMultiplexer _connection = Substitute.For<IConnectionMultiplexer>();
    private readonly StreamConfig _config = new();
    
    [Fact]
    public async Task Initialise_OnlyInitialisesOnce_WhenCalledMultipleTimes()
    {
        // Arrange
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
        var key = _fixture.Create<string>();
        var expressionReturn = _fixture.Create<string>();
        Assert.Throws<InvalidOperationException>(() => StreamManager.AddSubscription(key, () => expressionReturn));
    }

    [Fact]
    public void RemoveSubscription_ThrowsException_WhenUninitialised()
    {
        var key = _fixture.Create<string>();
        Assert.Throws<InvalidOperationException>(() => StreamManager.RemoveSubscription(key));
    }
    
    [Fact]
    public void TryGet_ThrowsException_WhenUninitialised()
    {
        var key = _fixture.Create<string>();
        Assert.Throws<InvalidOperationException>(() => StreamManager.TryGet<string>(key, out _));
    }

    [Fact]
    public void SetValue_ThrowsException_WhenUninitialised()
    {
        var key = _fixture.Create<ulong>();
        var value = _fixture.Create<string>();
        Assert.Throws<InvalidOperationException>(() => StreamManager.SetValue(key, value));
    }
}
