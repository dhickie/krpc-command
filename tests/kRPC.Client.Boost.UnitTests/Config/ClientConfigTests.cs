using kRPC.Client.Boost.Configuration;
using kRPC.Client.Boost.Exceptions;

namespace kRPC.Client.Boost.UnitTests.Config;

public class ClientConfigTests
{
    [Fact]
    public void Validate_ThrowsException_WhenConfigIsInvalid()
    {
        var config = new ClientConfig
        {
            Connection = new ConnectionConfig
            {
                RpcPort = -1
            }
        };
        
        Assert.Throws<ConfigException>(() => config.Validate());
    }

    [Fact]
    public void Validate_DoesNothing_WhenConfigIsValid()
    {
        var config = new ClientConfig();
        config.Validate();
    }
}