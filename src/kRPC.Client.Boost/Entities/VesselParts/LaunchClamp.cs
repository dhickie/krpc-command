using BaseLaunchClamp = KRPC.Client.Services.SpaceCenter.LaunchClamp;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter LaunchClamp object.
/// </summary>
public class LaunchClamp
{
    internal BaseLaunchClamp Internal { get; }

    internal LaunchClamp(BaseLaunchClamp launchClamp)
    {
        Internal = launchClamp;
    }
    public Part Part
        => new Part(Internal.Part);
    public void Release()
        => Internal.Release();
}
