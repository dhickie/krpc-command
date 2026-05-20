#if NET35
using systemAlias = global::KRPC.Client.Compatibility;
using genericCollectionsAlias = global::KRPC.Client.Compatibility;
#else
#endif

namespace kRPC.Client.Boost.Services.SpaceCenter
{
    /// <summary>
    /// Extension methods for SpaceCenter service.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Create an instance of the SpaceCenter service.
        /// </summary>
        public static global::kRPC.Client.Boost.Services.SpaceCenterService SpaceCenter (this global::KRPC.Client.IConnection connection)
        {
            return new global::kRPC.Client.Boost.Services.SpaceCenterService (connection);
        }
    }
}
