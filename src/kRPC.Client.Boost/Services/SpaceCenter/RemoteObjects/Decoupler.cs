using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// A decoupler. Obtained by calling <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Part.GetDecoupler" /></summary>
public class Decoupler : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    internal Decoupler(IConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Fires the decoupler. Returns the new vessel created when the decoupler fires.
    /// Throws an exception if the decoupler has already fired.
    /// </summary>
    /// <remarks>
    /// When called, the active vessel may change. It is therefore possible that,
    /// after calling this function, the object(s) returned by previous call(s) to
    /// <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.SpaceCenter.GetActiveVessel" /> no longer refer to the active vessel.
    /// </remarks>
    [SetRpc("SpaceCenter", "Decoupler_Decouple")]
    public Vessel Decouple()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<Vessel>("SpaceCenter", "Decoupler_Decouple", args);
    }

    /// <summary>
    /// Fires the decoupler. Returns the new vessel created when the decoupler fires.
    /// Throws an exception if the decoupler has already fired.
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>
    /// When called, the active vessel may change. It is therefore possible that,
    /// after calling this function, the object(s) returned by previous call(s) to
    /// <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.SpaceCenter.GetActiveVessel" /> no longer refer to the active vessel.
    /// </remarks>
    [SetRpc("SpaceCenter", "Decoupler_Decouple")]
    public async Task<Vessel> DecoupleAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<Vessel>("SpaceCenter", "Decoupler_Decouple", args);
    }

    /// <summary>
    /// Gets the part attached to this decoupler's explosive node.
    /// </summary>
    [GetRpc("SpaceCenter", "Decoupler_get_AttachedPart")]
    public Part GetAttachedPart()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<Part>("SpaceCenter", "Decoupler_get_AttachedPart", args);
    }

    /// <summary>
    /// Gets the part attached to this decoupler's explosive node.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Decoupler_get_AttachedPart")]
    public async Task<Part> GetAttachedPartAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<Part>("SpaceCenter", "Decoupler_get_AttachedPart", args);
    }

    /// <summary>
    /// Gets whether the decoupler has fired.
    /// </summary>
    [GetRpc("SpaceCenter", "Decoupler_get_Decoupled")]
    public bool GetDecoupled()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "Decoupler_get_Decoupled", args);
    }

    /// <summary>
    /// Gets whether the decoupler has fired.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Decoupler_get_Decoupled")]
    public async Task<bool> GetDecoupledAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "Decoupler_get_Decoupled", args);
    }

    /// <summary>
    /// Gets the impulse that the decoupler imparts when it is fired, in Newton seconds.
    /// </summary>
    [GetRpc("SpaceCenter", "Decoupler_get_Impulse")]
    public float GetImpulse()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<float>("SpaceCenter", "Decoupler_get_Impulse", args);
    }

    /// <summary>
    /// Gets the impulse that the decoupler imparts when it is fired, in Newton seconds.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Decoupler_get_Impulse")]
    public async Task<float> GetImpulseAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<float>("SpaceCenter", "Decoupler_get_Impulse", args);
    }

    /// <summary>
    /// Gets whether the decoupler is an omni-decoupler (e.g. stack separator)
    /// </summary>
    [GetRpc("SpaceCenter", "Decoupler_get_IsOmniDecoupler")]
    public bool GetIsOmniDecoupler()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "Decoupler_get_IsOmniDecoupler", args);
    }

    /// <summary>
    /// Gets whether the decoupler is an omni-decoupler (e.g. stack separator)
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Decoupler_get_IsOmniDecoupler")]
    public async Task<bool> GetIsOmniDecouplerAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "Decoupler_get_IsOmniDecoupler", args);
    }

    /// <summary>
    /// Gets the part object for this decoupler.
    /// </summary>
    [GetRpc("SpaceCenter", "Decoupler_get_Part")]
    public Part GetPart()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<Part>("SpaceCenter", "Decoupler_get_Part", args);
    }

    /// <summary>
    /// Gets the part object for this decoupler.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Decoupler_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<Part>("SpaceCenter", "Decoupler_get_Part", args);
    }

    /// <summary>
    /// Gets whether the decoupler is enabled in the staging sequence.
    /// </summary>
    [GetRpc("SpaceCenter", "Decoupler_get_Staged")]
    public bool GetStaged()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "Decoupler_get_Staged", args);
    }

    /// <summary>
    /// Gets whether the decoupler is enabled in the staging sequence.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Decoupler_get_Staged")]
    public async Task<bool> GetStagedAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "Decoupler_get_Staged", args);
    }
}
