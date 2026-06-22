using kRPC.Client.Boost.Services.KRPC;
using kRPC.Client.Boost.Services.SpaceCenter;

namespace kRPC.Client.Boost.Connection;

/// <summary>
/// A connection to the kRPC server.
/// All interaction with kRPC starts with an instance of this interface.
/// </summary>
public interface IConnection : IDisposable
{
    /// <summary>
    /// Returns an object providing access to the KRPC service.
    /// </summary>
    KRPC KRPC { get; }
    
    /// <summary>
    /// Returns an object providing access to the SpaceCenter service.
    /// </summary>
    SpaceCenter SpaceCenter { get; }
}