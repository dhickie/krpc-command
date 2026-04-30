using BaseRoboticController = KRPC.Client.Services.SpaceCenter.RoboticController;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter RoboticController object.
/// </summary>
public class RoboticController
{
    internal BaseRoboticController Internal { get; }

    internal RoboticController(BaseRoboticController roboticController)
    {
        Internal = roboticController;
    }
    public Part Part
        => new Part(Internal.Part);
    public bool AddAxis(Module module, string fieldName)
        => Internal.AddAxis(module.Internal, fieldName);
    public bool AddKeyFrame(Module module, string fieldName, float time, float value)
        => Internal.AddKeyFrame(module.Internal, fieldName, time, value);
    public IList<IList<string>> Axes()
        => Internal.Axes();
    public bool ClearAxis(Module module, string fieldName)
        => Internal.ClearAxis(module.Internal, fieldName);
    public bool HasPart(Part part)
        => Internal.HasPart(part.Internal);
}
