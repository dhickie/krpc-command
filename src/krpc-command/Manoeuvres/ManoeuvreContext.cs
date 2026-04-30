using KRPC.Client;
using KRPC.Client.Services.MechJeb;
using KRPC.Client.Services.SpaceCenter;

namespace KrpcCommand.Manoeuvres;

/// <summary>
/// Provides access to kRPC services during manoeuvre execution.
/// </summary>
public class ManoeuvreContext
{
    public Connection Connection { get; }
    public KRPC.Client.Services.SpaceCenter.Service SpaceCenter { get; }
    public KRPC.Client.Services.MechJeb.Service MechJeb { get; }

    public ManoeuvreContext(Connection connection)
    {
        Connection = connection;
        SpaceCenter = connection.SpaceCenter();
        MechJeb = connection.MechJeb();
    }

    /// <summary>
    /// Shortcut to get the active vessel.
    /// </summary>
    public Vessel ActiveVessel => SpaceCenter.ActiveVessel;

    /// <summary>
    /// Shortcut to get the current universal time.
    /// </summary>
    public double UT => SpaceCenter.UT;
}
