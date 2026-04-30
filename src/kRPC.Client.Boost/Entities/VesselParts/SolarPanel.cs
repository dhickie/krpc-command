using KRPC.Client.Services.SpaceCenter;
using BaseSolarPanel = KRPC.Client.Services.SpaceCenter.SolarPanel;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter SolarPanel object.
/// </summary>
public class SolarPanel
{
    internal BaseSolarPanel Internal { get; }

    internal SolarPanel(BaseSolarPanel solarPanel)
    {
        Internal = solarPanel;
    }
    public bool Deployable
        => Internal.Deployable;
    public bool Deployed
    {
        get => Internal.Deployed;
        set => Internal.Deployed = value;
    }
    public float EnergyFlow
        => Internal.EnergyFlow;
    public Part Part
        => new Part(Internal.Part);
    public SolarPanelState State
        => Internal.State;
    public float SunExposure
        => Internal.SunExposure;
}
