using System.Net;
using kRPC.Client.Boost.Config;

namespace kRPC.Client.Boost.UnitTests.Config;

public class ConnectionConfigTests : ConfigTestBase
{
    [Theory]
    [InlineData("0.0.0.0")]
    [InlineData("255.255.255.255")]
    [InlineData("::")]
    public void ValidationFails_WhenIPIsInvalid(string ipAddress)
    {
        var ip = IPAddress.Parse(ipAddress);
        var config = new ConnectionConfig
        {
            Address = ip
        };

        AssertConfigHasValidationErrors(config);
    }

    [Theory]
    [InlineData(-1, 80)]
    [InlineData(80, -1)]
    [InlineData(65536, 80)]
    [InlineData(80, 65536)]
    [InlineData(80, 80)]
    public void ValidationFails_WhenPortIsInvalid(int rpcPort, int streamPort)
    {
        var config = new ConnectionConfig
        {
            RpcPort = rpcPort,
            StreamPort = streamPort
        };
        
        AssertConfigHasValidationErrors(config);
    }

    [Fact]
    public void ValidationPasses_WhenUsingDefaults()
    {
        var config = new ConnectionConfig();
        AssertConfigIsValid(config);
    }

    [Fact]
    public void ValidationPasses_WhenUsingValidCustomValues()
    {
        var config = new ConnectionConfig
        {
            Address = IPAddress.Parse("192.168.1.1"),
            RpcPort = 8080,
            StreamPort = 8081
        };
        
        AssertConfigIsValid(config);
    }
}