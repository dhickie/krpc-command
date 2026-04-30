using KRPC.Client.Services.SpaceCenter;
using BaseSolarPanel = KRPC.Client.Services.SpaceCenter.SolarPanel;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter SolarPanel object.
/// </summary>
public class SolarPanel
{
    internal readonly BaseSolarPanel Wrapped;

    internal SolarPanel(BaseSolarPanel solarPanel)
    {
        Wrapped = solarPanel;
    }

    public bool Deployable
        => Wrapped.Deployable;

    public bool Deployed
    {
        get => Wrapped.Deployed;
        set => Wrapped.Deployed = value;
    }

    public float EnergyFlow
        => Wrapped.EnergyFlow;

    public Part Part
        => new Part(Wrapped.Part);

    public SolarPanelState State
        => Wrapped.State;

    public float SunExposure
        => Wrapped.SunExposure;
}
