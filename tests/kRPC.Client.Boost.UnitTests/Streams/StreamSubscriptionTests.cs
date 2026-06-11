using System.Linq.Expressions;
using AutoFixture;
using kRPC.Client.Boost.Config;
using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services.KRPC.RemoteObjects;
using kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;
using kRPC.Client.Boost.Streams;
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
        var vessel = new Vessel(_connection, _fixture.Create<ulong>());
        _connection.AddStream(Arg.Any<Expression<Func<float>>>(), true)
            .Returns(new RemoteStream(_connection, _fixture.Create<ulong>()));
        
        // Act
        _ = new StreamSubscription(() => vessel.GetAvailableThrust());
        
        // Assert
        _connection.Received(1).AddStream(Arg.Any<Expression<Func<float>>>(), true);
    }

    [Fact]
    public void Constructor_AddsMultipleStreams_WhenGivenMultipleExpressions()
    {
        // Arrange
        var vessel = new Vessel(_connection, _fixture.Create<ulong>());
        _connection.AddStream(Arg.Any<Expression<Func<float>>>(), true)
            .Returns(new RemoteStream(_connection, _fixture.Create<ulong>()));
        
        // Act
        _ = new StreamSubscription(
            () => vessel.GetAvailableThrust(),
            () => vessel.GetThrust());
        
        // Assert
        _connection.Received(2).AddStream(Arg.Any<Expression<Func<float>>>(), true);
    }
}