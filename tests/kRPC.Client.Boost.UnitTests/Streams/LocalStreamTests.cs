using System.Linq.Expressions;
using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services.KRPC.RemoteObjects;
using kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;
using kRPC.Client.Boost.Streams;
using kRPC.Client.Boost.UnitTests.Fakes;
using NSubstitute;

namespace kRPC.Client.Boost.UnitTests.Streams;

public class LocalStreamTests
{
    [Fact]
    public void InitialisesStream_OnCreation()
    {
        // Assemble
        var connection = Substitute.For<IConnectionMultiplexer>();
        var stream = new RemoteStream(connection, 1);
        connection.AddStream(Arg.Any<Expression<Func<string>>>(), Arg.Any<bool>())
            .Returns(stream);
        var vessel = new Vessel(connection, 1);
        Expression<Func<string>> expression = () => vessel.GetBiome();
        
        // Act
        var localStream = new LocalStream<string>(connection, expression);
        
        // Assert
        Assert.Equal(stream.Id, localStream.RemoteId);
        connection.Received().AddStream(expression, true);
    }
}