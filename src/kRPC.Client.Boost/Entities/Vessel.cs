using BaseVessel = KRPC.Client.Services.SpaceCenter.Vessel;

namespace kRPC.Client.Boost.Entities;

public class Vessel
{
    private BaseVessel _vessel;
    
    internal Vessel(BaseVessel vessel)
    {
        _vessel = vessel;
    }
}