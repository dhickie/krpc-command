using KRPC.Client.Services.SpaceCenter;
using BaseParachute = KRPC.Client.Services.SpaceCenter.Parachute;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Parachute object.
/// </summary>
public class Parachute
{
    internal readonly BaseParachute Wrapped;

    internal Parachute(BaseParachute parachute)
    {
        Wrapped = parachute;
    }

    public bool Armed
        => Wrapped.Armed;

    public float DeployAltitude
    {
        get => Wrapped.DeployAltitude;
        set => Wrapped.DeployAltitude = value;
    }

    public float DeployMinPressure
    {
        get => Wrapped.DeployMinPressure;
        set => Wrapped.DeployMinPressure = value;
    }

    public bool Deployed
        => Wrapped.Deployed;

    public Part Part
        => new Part(Wrapped.Part);

    public ParachuteState State
        => Wrapped.State;

    public void Arm()
        => Wrapped.Arm();

    public void Cut()
        => Wrapped.Cut();

    public void Deploy()
        => Wrapped.Deploy();
}
