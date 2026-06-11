using System.Linq.Expressions;
using AutoFixture;
using kRPC.Client.Boost.Config;
using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services.KRPC.RemoteObjects;
using kRPC.Client.Boost.Services.SpaceCenter;
using kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;
using kRPC.Client.Boost.Streams;
using kRPC.Client.Boost.UnitTests.Helpers;
using MathNet.Spatial.Euclidean;
using NSubstitute;

namespace kRPC.Client.Boost.UnitTests.Streams;

[Collection("Serial")]
public class StreamSubscriptionTests
{
    private readonly IConnectionMultiplexer _connection;
    private readonly Fixture _fixture;

    public StreamSubscriptionTests()
    {
        _connection = Substitute.For<IConnectionMultiplexer>();
        _fixture = new Fixture();
        
        StreamManager.Reset();
        StreamManager.Initialise(_connection, new StreamConfig());
    }

    [Fact]
    public void Constructor_ThrowsException_WhenGivenInvalidExpression()
    {
        Assert.Throws<ArgumentException>(() => new StreamSubscription(() => "hello"));
    }

    [Fact]
    public void Constructor_AddsStream_WhenGivenValidExpression()
    {
        // Arrange
        var vessel = RemoteObjectFixture.Create<Vessel>();
        ConfigureConnection<float>();
        
        // Act
        _ = new StreamSubscription(() => vessel.GetAvailableThrust());
        
        // Assert
        _connection.Received(1).AddStream(Arg.Any<Expression<Func<float>>>(), true);
    }

    [Fact]
    public void Constructor_AddsMultipleStreams_WhenGivenMultipleExpressions()
    {
        // Arrange
        var vessel = RemoteObjectFixture.Create<Vessel>();
        ConfigureConnection<float>();
        
        // Act
        _ = new StreamSubscription(
            () => vessel.GetAvailableThrust(),
            () => vessel.GetThrust());
        
        // Assert
        _connection.Received(2).AddStream(Arg.Any<Expression<Func<float>>>(), true);
    }
    
    [Fact]
    public void Constructor_ThrowsException_WhenGivenOneValidAndOneInvalidExpression()
    {
        // Arrange
        var vessel = RemoteObjectFixture.Create<Vessel>();
        ConfigureConnection<float>();
        
        // Act & Assert
        Assert.Throws<ArgumentException>(() => 
            new StreamSubscription(
                () => vessel.GetAvailableThrust(),
                () => 0F));
        _connection.Received(0).AddStream(Arg.Any<Expression<Func<float>>>(), true);
    }

    [Fact]
    public void Constructor_AddsMultipleStreams_WhenSameRpcCalledOnDifferentObjects()
    {
        // Arrange
        var vesselA = RemoteObjectFixture.Create<Vessel>();
        var vesselB = RemoteObjectFixture.Create<Vessel>();
        ConfigureConnection<float>();
        
        // Act
        _ = new StreamSubscription(
            () => vesselA.GetAvailableThrust(),
            () => vesselB.GetAvailableThrust());
        
        // Assert
        _connection.Received(2).AddStream(Arg.Any<Expression<Func<float>>>(), true);
    }

    [Fact]
    public void Constructor_AddOneStream_WhenGivenTwoIdenticalExpressions()
    {
        // Arrange
        var vessel = RemoteObjectFixture.Create<Vessel>();
        ConfigureConnection<float>();
        
        // Act
        _ = new StreamSubscription(
            () => vessel.GetAvailableThrust(),
            () => vessel.GetAvailableThrust());
        
        // Assert
        _connection.Received(1).AddStream(Arg.Any<Expression<Func<float>>>(), true);
    }

    [Fact]
    public void Constructor_AddsMultipleStreams_ForRpcsReturningDifferentTypes()
    {
        // Arrange
        var vessel = RemoteObjectFixture.Create<Vessel>();
        ConfigureConnection<float>();
        ConfigureConnection<string>();
        
        // Act
        _ = new StreamSubscription(
            () => vessel.GetAvailableThrust(),
            () => vessel.GetBiome());
        
        // Assert
        _connection.Received(1).AddStream(Arg.Any<Expression<Func<float>>>(), true);
        _connection.Received(1).AddStream(Arg.Any<Expression<Func<string>>>(), true);
    }

    [Fact]
    public void Constructor_AddsStream_ForRpcReturningRemoteObject()
    {
        // Arrange
        var vessel = RemoteObjectFixture.Create<Vessel>();
        ConfigureConnection<ReferenceFrame>();
        
        // Act
        _ = new StreamSubscription(() => vessel.GetOrbitalReferenceFrame());
        
        // Assert
        _connection.Received(1).AddStream(Arg.Any<Expression<Func<ReferenceFrame>>>(), true);
    }

    [Fact]
    public void Constructor_AddsStream_ForRpcInvokedOnNonRemoteObject()
    {
        // Arrange
        var spaceCentre = new SpaceCenter(_connection);
        ConfigureConnection<bool>();
        
        // Act
        _ = new StreamSubscription(() => spaceCentre.CanRailsWarpAt(1));
        
        // Assert
        _connection.Received(1).AddStream(Arg.Any<Expression<Func<bool>>>(), true);
    }

    [Fact]
    public void Constructor_AddsStream_ForRpcInvokedWithArguments()
    {
        // Arrange
        var vessel = RemoteObjectFixture.Create<Vessel>();
        var rFrame = RemoteObjectFixture.Create<ReferenceFrame>();
        ConfigureConnection<Vector3D>();
        
        // Act
        _ = new StreamSubscription(() => vessel.GetVelocity(rFrame));
        
        // Assert
        _connection.Received(1).AddStream(Arg.Any<Expression<Func<Vector3D>>>(), true);
    }
    
    [Fact]
    public void Constructor_AddsMultipleStreams_ForRpcInvokedMultipleTimesWithDifferentArguments()
    {
        // Arrange
        var vessel = RemoteObjectFixture.Create<Vessel>();
        var rFrameA = RemoteObjectFixture.Create<ReferenceFrame>();
        var rFrameB = RemoteObjectFixture.Create<ReferenceFrame>();
        ConfigureConnection<Vector3D>();
        
        // Act
        _ = new StreamSubscription(
            () => vessel.GetVelocity(rFrameA),
            () => vessel.GetVelocity(rFrameB));
        
        // Assert
        _connection.Received(2).AddStream(Arg.Any<Expression<Func<Vector3D>>>(), true);
    }
    
    [Fact]
    public void Constructor_ThrowsException_WhenCalledWithSetterRpc()
    {
        // Arrange
        var vessel = RemoteObjectFixture.Create<Vessel>();
        
        // Act & Assert
        Assert.Throws<ArgumentException>(() => 
            new StreamSubscription(() => vessel.SetName(_fixture.Create<string>())));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Dispose_RemovesSubscriptions(int numStreams)
    {
        // Arrange
        ConfigureConnection<float>();
        var expressions = new LambdaExpression[numStreams];
        for (var i = 0; i < numStreams; i++)
        {
            var vessel = RemoteObjectFixture.Create<Vessel>();
            expressions[i] = () => vessel.GetAvailableThrust();
        }

        var subscription = new StreamSubscription(expressions);
        
        // Act
        subscription.Dispose();
        
        // Assert
        _connection.Received(numStreams).RemoveStream(Arg.Any<ulong>());
    }

    private void ConfigureConnection<T>()
    {
        _connection.AddStream(Arg.Any<Expression<Func<T>>>(), true)
            .Returns(_ => new RemoteStream(_connection, _fixture.Create<ulong>()));
    }
}
