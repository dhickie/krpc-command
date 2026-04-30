using BaseExperiment = KRPC.Client.Services.SpaceCenter.Experiment;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Experiment object.
/// </summary>
public class Experiment
{
    internal BaseExperiment Internal { get; }

    internal Experiment(BaseExperiment experiment)
    {
        Internal = experiment;
    }
    public bool Available
        => Internal.Available;
    public string Biome
        => Internal.Biome;
    public IList<ScienceData> Data
        => Internal.Data.Select(item => new ScienceData(item)).ToList();
    public bool Deployed
        => Internal.Deployed;
    public bool HasData
        => Internal.HasData;
    public bool Inoperable
        => Internal.Inoperable;
    public string Name
        => Internal.Name;
    public Part Part
        => new Part(Internal.Part);
    public bool Rerunnable
        => Internal.Rerunnable;
    public ScienceSubject ScienceSubject
        => new ScienceSubject(Internal.ScienceSubject);
    public string Title
        => Internal.Title;
    public void Dump()
        => Internal.Dump();
    public void Reset()
        => Internal.Reset();
    public void Run()
        => Internal.Run();
    public void Transmit()
        => Internal.Transmit();
}
