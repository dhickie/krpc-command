using BaseExperiment = KRPC.Client.Services.SpaceCenter.Experiment;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Experiment object.
/// </summary>
public class Experiment
{
    internal readonly BaseExperiment Wrapped;

    internal Experiment(BaseExperiment experiment)
    {
        Wrapped = experiment;
    }

    public bool Available
        => Wrapped.Available;

    public string Biome
        => Wrapped.Biome;

    public IList<ScienceData> Data
        => Wrapped.Data.Select(item => new ScienceData(item)).ToList();

    public bool Deployed
        => Wrapped.Deployed;

    public bool HasData
        => Wrapped.HasData;

    public bool Inoperable
        => Wrapped.Inoperable;

    public string Name
        => Wrapped.Name;

    public Part Part
        => new Part(Wrapped.Part);

    public bool Rerunnable
        => Wrapped.Rerunnable;

    public ScienceSubject ScienceSubject
        => new ScienceSubject(Wrapped.ScienceSubject);

    public string Title
        => Wrapped.Title;

    public void Dump()
        => Wrapped.Dump();

    public void Reset()
        => Wrapped.Reset();

    public void Run()
        => Wrapped.Run();

    public void Transmit()
        => Wrapped.Transmit();
}
