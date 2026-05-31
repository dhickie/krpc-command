using kRPC.Client.Boost.Config;

namespace kRPC.Client.Boost.UnitTests.Config;

public class ConfigTestBase
{
    protected static void AssertConfigHasValidationErrors(Boost.Config.Config config)
    {
        var errors = new List<string>();
        config.Validate(errors);
        
        Assert.True(errors.Count > 0);
    }
    
    protected static void AssertConfigIsValid(Boost.Config.Config config)
    {
        var errors = new List<string>();
        config.Validate(errors);
        
        Assert.Empty(errors);
    }
}