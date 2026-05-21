using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// Obtained by calling <see cref="M:SpaceCenter.Experiment.GetScienceSubject" />.
/// </summary>
public class ScienceSubject : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public ScienceSubject(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Multiply science value by this to determine data amount in mits.
    /// </summary>
    [Rpc("SpaceCenter", "ScienceSubject_get_DataScale")]
    public float GetDataScale()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "ScienceSubject_get_DataScale", args);
    }

    /// <summary>
    /// Multiply science value by this to determine data amount in mits.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ScienceSubject_get_DataScale")]
    public async Task<float> GetDataScaleAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "ScienceSubject_get_DataScale", args);
    }

    /// <summary>
    /// Gets whether the experiment has been completed.
    /// </summary>
    [Rpc("SpaceCenter", "ScienceSubject_get_IsComplete")]
    public bool GetIsComplete()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "ScienceSubject_get_IsComplete", args);
    }

    /// <summary>
    /// Gets whether the experiment has been completed.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ScienceSubject_get_IsComplete")]
    public async Task<bool> GetIsCompleteAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "ScienceSubject_get_IsComplete", args);
    }

    /// <summary>
    /// Amount of science already earned from this subject, not updated until after
    /// transmission/recovery.
    /// </summary>
    [Rpc("SpaceCenter", "ScienceSubject_get_Science")]
    public float GetScience()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "ScienceSubject_get_Science", args);
    }

    /// <summary>
    /// Amount of science already earned from this subject, not updated until after
    /// transmission/recovery.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ScienceSubject_get_Science")]
    public async Task<float> GetScienceAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "ScienceSubject_get_Science", args);
    }

    /// <summary>
    /// Gets the total science allowable for this subject.
    /// </summary>
    [Rpc("SpaceCenter", "ScienceSubject_get_ScienceCap")]
    public float GetScienceCap()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "ScienceSubject_get_ScienceCap", args);
    }

    /// <summary>
    /// Gets the total science allowable for this subject.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ScienceSubject_get_ScienceCap")]
    public async Task<float> GetScienceCapAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "ScienceSubject_get_ScienceCap", args);
    }

    /// <summary>
    /// Diminishing value multiplier for decreasing the science value returned from repeated
    /// experiments.
    /// </summary>
    [Rpc("SpaceCenter", "ScienceSubject_get_ScientificValue")]
    public float GetScientificValue()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "ScienceSubject_get_ScientificValue", args);
    }

    /// <summary>
    /// Diminishing value multiplier for decreasing the science value returned from repeated
    /// experiments.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ScienceSubject_get_ScientificValue")]
    public async Task<float> GetScientificValueAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "ScienceSubject_get_ScientificValue", args);
    }

    /// <summary>
    /// Multiplier for specific Celestial Body/Experiment Situation combination.
    /// </summary>
    [Rpc("SpaceCenter", "ScienceSubject_get_SubjectValue")]
    public float GetSubjectValue()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "ScienceSubject_get_SubjectValue", args);
    }

    /// <summary>
    /// Multiplier for specific Celestial Body/Experiment Situation combination.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ScienceSubject_get_SubjectValue")]
    public async Task<float> GetSubjectValueAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "ScienceSubject_get_SubjectValue", args);
    }

    /// <summary>
    /// Title of science subject, displayed in science archives
    /// </summary>
    [Rpc("SpaceCenter", "ScienceSubject_get_Title")]
    public string GetTitle()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<string>("SpaceCenter", "ScienceSubject_get_Title", args);
    }

    /// <summary>
    /// Title of science subject, displayed in science archives
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ScienceSubject_get_Title")]
    public async Task<string> GetTitleAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<string>("SpaceCenter", "ScienceSubject_get_Title", args);
    }
}
