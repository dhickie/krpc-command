using kRPC.Client.Boost.IntegrationTests.Server;

namespace kRPC.Client.Boost.IntegrationTests.TestCollections;

[CollectionDefinition("IntegrationTests")]
public class IntegrationTestCollection : ICollectionFixture<TestServer>;