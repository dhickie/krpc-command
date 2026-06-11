namespace kRPC.Client.Boost.UnitTests.TestCollections;

// For tests that cannot be run in parallel due to use of static state
[CollectionDefinition("Serial", DisableParallelization = true)]
public class SerialTestCollection
{
    
}