using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// A propellant for an engine. Obtains by calling <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Engine.GetPropellants" />.
/// </summary>
public class Propellant : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    internal Propellant(IConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Gets the current amount of propellant.
    /// </summary>
    [GetRpc("SpaceCenter", "Propellant_get_CurrentAmount")]
    public double GetCurrentAmount()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "Propellant_get_CurrentAmount", args);
    }

    /// <summary>
    /// Gets the current amount of propellant.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Propellant_get_CurrentAmount")]
    public async Task<double> GetCurrentAmountAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "Propellant_get_CurrentAmount", args);
    }

    /// <summary>
    /// Gets the required amount of propellant.
    /// </summary>
    [GetRpc("SpaceCenter", "Propellant_get_CurrentRequirement")]
    public double GetCurrentRequirement()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "Propellant_get_CurrentRequirement", args);
    }

    /// <summary>
    /// Gets the required amount of propellant.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Propellant_get_CurrentRequirement")]
    public async Task<double> GetCurrentRequirementAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "Propellant_get_CurrentRequirement", args);
    }

    /// <summary>
    /// If this propellant has a stack gauge or not.
    /// </summary>
    [GetRpc("SpaceCenter", "Propellant_get_DrawStackGauge")]
    public bool GetDrawStackGauge()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "Propellant_get_DrawStackGauge", args);
    }

    /// <summary>
    /// If this propellant has a stack gauge or not.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Propellant_get_DrawStackGauge")]
    public async Task<bool> GetDrawStackGaugeAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "Propellant_get_DrawStackGauge", args);
    }

    /// <summary>
    /// If this propellant should be ignored when calculating required mass flow
    /// given specific impulse.
    /// </summary>
    [GetRpc("SpaceCenter", "Propellant_get_IgnoreForIsp")]
    public bool GetIgnoreForIsp()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "Propellant_get_IgnoreForIsp", args);
    }

    /// <summary>
    /// If this propellant should be ignored when calculating required mass flow
    /// given specific impulse.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Propellant_get_IgnoreForIsp")]
    public async Task<bool> GetIgnoreForIspAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "Propellant_get_IgnoreForIsp", args);
    }

    /// <summary>
    /// If this propellant should be ignored for thrust curve calculations.
    /// </summary>
    [GetRpc("SpaceCenter", "Propellant_get_IgnoreForThrustCurve")]
    public bool GetIgnoreForThrustCurve()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "Propellant_get_IgnoreForThrustCurve", args);
    }

    /// <summary>
    /// If this propellant should be ignored for thrust curve calculations.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Propellant_get_IgnoreForThrustCurve")]
    public async Task<bool> GetIgnoreForThrustCurveAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "Propellant_get_IgnoreForThrustCurve", args);
    }

    /// <summary>
    /// If this propellant is deprived.
    /// </summary>
    [GetRpc("SpaceCenter", "Propellant_get_IsDeprived")]
    public bool GetIsDeprived()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "Propellant_get_IsDeprived", args);
    }

    /// <summary>
    /// If this propellant is deprived.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Propellant_get_IsDeprived")]
    public async Task<bool> GetIsDeprivedAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "Propellant_get_IsDeprived", args);
    }

    /// <summary>
    /// Gets the name of the propellant.
    /// </summary>
    [GetRpc("SpaceCenter", "Propellant_get_Name")]
    public string GetName()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<string>("SpaceCenter", "Propellant_get_Name", args);
    }

    /// <summary>
    /// Gets the name of the propellant.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Propellant_get_Name")]
    public async Task<string> GetNameAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<string>("SpaceCenter", "Propellant_get_Name", args);
    }

    /// <summary>
    /// Gets the propellant ratio.
    /// </summary>
    [GetRpc("SpaceCenter", "Propellant_get_Ratio")]
    public float GetRatio()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<float>("SpaceCenter", "Propellant_get_Ratio", args);
    }

    /// <summary>
    /// Gets the propellant ratio.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Propellant_get_Ratio")]
    public async Task<float> GetRatioAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<float>("SpaceCenter", "Propellant_get_Ratio", args);
    }

    /// <summary>
    /// Gets the total amount of the underlying resource currently reachable given
    /// resource flow rules.
    /// </summary>
    [GetRpc("SpaceCenter", "Propellant_get_TotalResourceAvailable")]
    public double GetTotalResourceAvailable()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "Propellant_get_TotalResourceAvailable", args);
    }

    /// <summary>
    /// Gets the total amount of the underlying resource currently reachable given
    /// resource flow rules.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Propellant_get_TotalResourceAvailable")]
    public async Task<double> GetTotalResourceAvailableAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "Propellant_get_TotalResourceAvailable", args);
    }

    /// <summary>
    /// Gets the total vehicle capacity for the underlying propellant resource,
    /// restricted by resource flow rules.
    /// </summary>
    [GetRpc("SpaceCenter", "Propellant_get_TotalResourceCapacity")]
    public double GetTotalResourceCapacity()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "Propellant_get_TotalResourceCapacity", args);
    }

    /// <summary>
    /// Gets the total vehicle capacity for the underlying propellant resource,
    /// restricted by resource flow rules.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Propellant_get_TotalResourceCapacity")]
    public async Task<double> GetTotalResourceCapacityAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "Propellant_get_TotalResourceCapacity", args);
    }
}
