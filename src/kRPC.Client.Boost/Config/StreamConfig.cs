using System.Text;

namespace kRPC.Client.Boost.Config;

public class StreamConfig(
    TimeSpan? compactionInterval = null,
    int? initialDictionarySize = null,
    int? maxDictionarySize = null, 
    int? maxDictionarySizeIncreaseInterval = null) : Config
{
    public TimeSpan CompactionInterval = compactionInterval ?? TimeSpan.FromSeconds(10);
    public int InitialDictionarySize = initialDictionarySize ?? 1024;
    public int MaxDictionarySize = maxDictionarySize ?? 8192;
    public int MaxDictionarySizeIncreaseInterval = maxDictionarySizeIncreaseInterval ?? 512;


    protected override void Validate()
    {
        IsInvalid(CompactionInterval, x => x > TimeSpan.Zero, "CompactionInterval must be a positive interval");
        IsInvalid(InitialDictionarySize, x => x > 0, "InitialDictionarySize must be a positive number");
        IsInvalid(MaxDictionarySize, x => x <= 0, "MaxDictionarySize must be greater than 0");
        IsInvalid(MaxDictionarySizeIncreaseInterval, x => x <= 0, "MaxDictionarySizeIncreaseInterval must be greater than 0");
        IsInvalid(InitialDictionarySize, MaxDictionarySize, (x, y) => x > y, "InitialDictionarySize must be less than or equal to MaxDictionarySize");
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine("Stream:");
        builder.AppendLine($"  {nameof(CompactionInterval)} (seconds): {CompactionInterval.TotalSeconds}");
        builder.AppendLine($"  {nameof(InitialDictionarySize)}: {InitialDictionarySize}");
        builder.AppendLine($"  {nameof(MaxDictionarySize)}: {MaxDictionarySize}");
        builder.AppendLine($"  {nameof(MaxDictionarySizeIncreaseInterval)}: {MaxDictionarySizeIncreaseInterval}");
        
        return builder.ToString();
    }
}