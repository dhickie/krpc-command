using KRPC.Client.Services.SpaceCenter;
using Vessel = kRPC.Client.Boost.Entities.Vessel;

namespace kRPC.Client.Boost.Services;

public class SpaceCenter(Service service)
{
    public Vessel ActiveVessel => new(service.ActiveVessel);
}