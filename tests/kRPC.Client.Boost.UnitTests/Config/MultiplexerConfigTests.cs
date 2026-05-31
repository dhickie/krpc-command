using System.Reflection;
using kRPC.Client.Boost.Config;

namespace kRPC.Client.Boost.UnitTests.Config;

public class MultiplexerConfigTests : ConfigTestBase
{
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void ValidationFails_WhenNumRpcConnectionsIsInvalid(int numRpcConnections)
    {
        var config = new MultiplexerConfig
        {
            NumRpcConnections = numRpcConnections
        };
        
        AssertConfigHasValidationErrors(config);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("   ")]
    public void ValidationFails_WhenClientNameIsInvalid(string clientName)
    {
        var config = new MultiplexerConfig
        {
            ClientName = clientName
        };
        
        AssertConfigHasValidationErrors(config);
    }

    [Fact]
    public void ValidationPasses_WhenUsingDefaults()
    {
        var config = new MultiplexerConfig();
        AssertConfigIsValid(config);
    }

    [Fact]
    public void ValidationPasses_WhenUsingValidCustomValues()
    {
        var config = new MultiplexerConfig
        {
            NumRpcConnections = 10,
            ClientName = "TestClient"
        };
        
        AssertConfigIsValid(config);
    }
}