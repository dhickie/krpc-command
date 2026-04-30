using BaseLaunchClamp = KRPC.Client.Services.SpaceCenter.LaunchClamp;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter LaunchClamp object.
/// </summary>
public class LaunchClamp
{
    internal readonly BaseLaunchClamp Wrapped;

    internal LaunchClamp(BaseLaunchClamp launchClamp)
    {
        Wrapped = launchClamp;
    }

    public Part Part
        => new Part(Wrapped.Part);

    public void Release()
        => Wrapped.Release();
}
