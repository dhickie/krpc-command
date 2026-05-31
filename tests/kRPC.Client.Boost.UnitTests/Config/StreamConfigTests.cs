using kRPC.Client.Boost.Config;

namespace kRPC.Client.Boost.UnitTests.Config;

public class StreamConfigTests : ConfigTestBase
{
    [Fact]
    public void ValidationFails_WhenCompactionIntervalIsInvalid()
    {
        var config = new StreamConfig
        {
            CompactionInterval = TimeSpan.Zero
        };

        AssertConfigHasValidationErrors(config);
    }

    [Theory]
    [InlineData(0, 100)]
    [InlineData(-1, 100)]
    [InlineData(100, 0)]
    [InlineData(100, -1)]
    [InlineData(100, 50)]
    public void ValidationFails_WhenDictionarySizesAreInvalid(int initialSize, int maxSize)
    {
        var config = new StreamConfig
        {
            InitialDictionarySize = initialSize,
            MaxDictionarySize = maxSize
        };
        
        AssertConfigHasValidationErrors(config);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void ValidationFails_WhenDictionaryIncreaseIntervalIsInvalid(int interval)
    {
        var config = new StreamConfig
        {
            MaxDictionarySizeIncreaseInterval = interval,
        };
        
        AssertConfigHasValidationErrors(config);
    }

    [Fact]
    public void ValidationPasses_WhenUsingDefaults()
    {
        var config = new StreamConfig();
        AssertConfigIsValid(config);
    }

    [Fact]
    public void ValidationPasses_WhenUsingCustomValidValues()
    {
        var config = new StreamConfig
        {
            CompactionInterval = TimeSpan.FromMinutes(1),
            InitialDictionarySize = 128,
            MaxDictionarySize = 1024,
            MaxDictionarySizeIncreaseInterval = 64
        };
        
        AssertConfigIsValid(config);
    }
}