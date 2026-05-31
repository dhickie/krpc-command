using System.Text;

namespace kRPC.Client.Boost.Config;

/// <summary>
/// Encapsulates all configuration related to stream management.
/// </summary>
/// <param name="compactionInterval">
///     The interval at which the stream manager should check for streams that no longer have any subscribers.
///     If the streams dictionary has reached it's max size, streams with no subscribers are then removed.
///     Creating new streams, adding/removing subscribers from existing streams, or tearing down streams are all blocked while compaction is in progress.
///     Having a long compaction interval will reduce this disruption, and the potential cost of higher memory usage.
///     Defaults to 10 seconds.
/// </param>
/// <param name="initialDictionarySize">
///     The initial number of items that can be kept in the streams dictionary before compaction starts to kick in.
///     Having a higher value means compaction will happen less, and have less disruption as a result.
///     However, this will also lead to higher memory usage.
///     Defaults to 1024.
/// </param>
/// <param name="maxDictionarySize">
///     The maximum permitted size of the streams dictionary.
///     Defaults to 8192.
/// </param>
/// <param name="maxDictionarySizeIncreaseInterval">
///     If the streams dictionary gets past the initial dictionary size, then compaction will start to kick in.
///     If the streams dictionary is still above the initial size after compaction, it is increased in size by this amount.
///     The size is only increased up to the configured max size.
///     Defaults to 512.
/// </param>
public class StreamConfig(
    TimeSpan? compactionInterval = null,
    int? initialDictionarySize = null,
    int? maxDictionarySize = null, 
    int? maxDictionarySizeIncreaseInterval = null) : Config
{
    /// <summary>
    /// The interval at which the stream manager should check for streams that no longer have any subscribers.
    /// If the streams dictionary has reached it's max size, streams with no subscribers are then removed.
    /// Creating new streams, adding/removing subscribers from existing streams, or tearing down streams are all blocked while compaction is in progress.
    /// Having a long compaction interval will reduce this disruption, and the potential cost of higher memory usage.
    /// </summary>
    public TimeSpan CompactionInterval = compactionInterval ?? TimeSpan.FromSeconds(10);
    
    /// <summary>
    /// The initial number of items that can be kept in the streams dictionary before compaction starts to kick in.
    /// Having a higher value means compaction will happen less, and have less disruption as a result.
    /// However, this will also lead to higher memory usage.
    /// </summary>
    public int InitialDictionarySize = initialDictionarySize ?? 1024;
    
    /// <summary>
    /// The maximum permitted size of the streams dictionary.
    /// </summary>
    public int MaxDictionarySize = maxDictionarySize ?? 8192;
    
    /// <summary>
    /// If the streams dictionary gets past the initial dictionary size, then compaction will start to kick in.
    /// If the streams dictionary is still above the initial size after compaction, it is increased in size by this amount.
    /// The size is only increased up to the configured max size.
    /// </summary>
    public int MaxDictionarySizeIncreaseInterval = maxDictionarySizeIncreaseInterval ?? 512;


    protected override void Validate()
    {
        IsInvalid(CompactionInterval, x => x == TimeSpan.Zero, "CompactionInterval must be a positive interval");
        IsInvalid(InitialDictionarySize, x => x <= 0, "InitialDictionarySize must be a positive number");
        IsInvalid(MaxDictionarySize, x => x <= 0, "MaxDictionarySize must be greater than 0");
        IsInvalid(MaxDictionarySizeIncreaseInterval, x => x <= 0, "MaxDictionarySizeIncreaseInterval must be greater than 0");
        IsInvalid(InitialDictionarySize, MaxDictionarySize, (x, y) => x > y, "InitialDictionarySize must be less than or equal to MaxDictionarySize");
    }

    /// <summary>
    /// Converts this configuration object to a formatted string.
    /// </summary>
    /// <returns>The configuration as a formatted string.</returns>
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