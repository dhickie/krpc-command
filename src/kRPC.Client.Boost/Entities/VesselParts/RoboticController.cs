using BaseRoboticController = KRPC.Client.Services.SpaceCenter.RoboticController;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter RoboticController object.
/// </summary>
public class RoboticController
{
    internal readonly BaseRoboticController Wrapped;

    internal RoboticController(BaseRoboticController roboticController)
    {
        Wrapped = roboticController;
    }

    public Part Part
        => new Part(Wrapped.Part);

    public bool AddAxis(Module module, string fieldName)
        => Wrapped.AddAxis(module.Wrapped, fieldName);

    public bool AddKeyFrame(Module module, string fieldName, float time, float value)
        => Wrapped.AddKeyFrame(module.Wrapped, fieldName, time, value);

    public IList<IList<string>> Axes()
        => Wrapped.Axes();

    public bool ClearAxis(Module module, string fieldName)
        => Wrapped.ClearAxis(module.Wrapped, fieldName);

    public bool HasPart(Part part)
        => Wrapped.HasPart(part.Wrapped);
}
