using KRPC.Client.Services.SpaceCenter;
using BaseParachute = KRPC.Client.Services.SpaceCenter.Parachute;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Parachute object.
/// </summary>
public class Parachute
{
    internal BaseParachute Internal { get; }

    internal Parachute(BaseParachute parachute)
    {
        Internal = parachute;
    }
    public bool Armed
        => Internal.Armed;
    public float DeployAltitude
    {
        get => Internal.DeployAltitude;
        set => Internal.DeployAltitude = value;
    }
    public float DeployMinPressure
    {
        get => Internal.DeployMinPressure;
        set => Internal.DeployMinPressure = value;
    }
    public bool Deployed
        => Internal.Deployed;
    public Part Part
        => new Part(Internal.Part);
    public ParachuteState State
        => Internal.State;
    public void Arm()
        => Internal.Arm();
    public void Cut()
        => Internal.Cut();
    public void Deploy()
        => Internal.Deploy();
}
