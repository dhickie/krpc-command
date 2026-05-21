using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A propellant for an engine. Obtains by calling <see cref="M:SpaceCenter.Engine.GetPropellants" />.
/// </summary>
public class Propellant : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Propellant (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Gets the current amount of propellant.
    /// </summary>
    [Rpc ("SpaceCenter", "Propellant_get_CurrentAmount")]
    public double GetCurrentAmount ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Propellant_get_CurrentAmount", args);
    }

    /// <summary>
    /// Gets the required amount of propellant.
    /// </summary>
    [Rpc ("SpaceCenter", "Propellant_get_CurrentRequirement")]
    public double GetCurrentRequirement ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Propellant_get_CurrentRequirement", args);
    }

    /// <summary>
    /// If this propellant has a stack gauge or not.
    /// </summary>
    [Rpc ("SpaceCenter", "Propellant_get_DrawStackGauge")]
    public bool GetDrawStackGauge ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Propellant_get_DrawStackGauge", args);
    }

    /// <summary>
    /// If this propellant should be ignored when calculating required mass flow
    /// given specific impulse.
    /// </summary>
    [Rpc ("SpaceCenter", "Propellant_get_IgnoreForIsp")]
    public bool GetIgnoreForIsp ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Propellant_get_IgnoreForIsp", args);
    }

    /// <summary>
    /// If this propellant should be ignored for thrust curve calculations.
    /// </summary>
    [Rpc ("SpaceCenter", "Propellant_get_IgnoreForThrustCurve")]
    public bool GetIgnoreForThrustCurve ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Propellant_get_IgnoreForThrustCurve", args);
    }

    /// <summary>
    /// If this propellant is deprived.
    /// </summary>
    [Rpc ("SpaceCenter", "Propellant_get_IsDeprived")]
    public bool GetIsDeprived ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Propellant_get_IsDeprived", args);
    }

    /// <summary>
    /// Gets the name of the propellant.
    /// </summary>
    [Rpc ("SpaceCenter", "Propellant_get_Name")]
    public string GetName ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<string> ("SpaceCenter", "Propellant_get_Name", args);
    }

    /// <summary>
    /// Gets the propellant ratio.
    /// </summary>
    [Rpc ("SpaceCenter", "Propellant_get_Ratio")]
    public float GetRatio ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Propellant_get_Ratio", args);
    }

    /// <summary>
    /// Gets the total amount of the underlying resource currently reachable given
    /// resource flow rules.
    /// </summary>
    [Rpc ("SpaceCenter", "Propellant_get_TotalResourceAvailable")]
    public double GetTotalResourceAvailable ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Propellant_get_TotalResourceAvailable", args);
    }

    /// <summary>
    /// Gets the total vehicle capacity for the underlying propellant resource,
    /// restricted by resource flow rules.
    /// </summary>
    [Rpc ("SpaceCenter", "Propellant_get_TotalResourceCapacity")]
    public double GetTotalResourceCapacity ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Propellant_get_TotalResourceCapacity", args);
    }
}
