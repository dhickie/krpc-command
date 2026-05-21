using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using Google.Protobuf;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A propellant for an engine. Obtains by calling <see cref="M:SpaceCenter.Engine.Propellants" />.
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
    /// The current amount of propellant.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Propellant_get_CurrentAmount")]
    public double CurrentAmount {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Propellant))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Propellant_get_CurrentAmount", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary>
    /// The required amount of propellant.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Propellant_get_CurrentRequirement")]
    public double CurrentRequirement {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Propellant))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Propellant_get_CurrentRequirement", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary>
    /// If this propellant has a stack gauge or not.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Propellant_get_DrawStackGauge")]
    public bool DrawStackGauge {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Propellant))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Propellant_get_DrawStackGauge", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// If this propellant should be ignored when calculating required mass flow
    /// given specific impulse.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Propellant_get_IgnoreForIsp")]
    public bool IgnoreForIsp {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Propellant))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Propellant_get_IgnoreForIsp", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// If this propellant should be ignored for thrust curve calculations.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Propellant_get_IgnoreForThrustCurve")]
    public bool IgnoreForThrustCurve {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Propellant))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Propellant_get_IgnoreForThrustCurve", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// If this propellant is deprived.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Propellant_get_IsDeprived")]
    public bool IsDeprived {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Propellant))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Propellant_get_IsDeprived", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// The name of the propellant.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Propellant_get_Name")]
    public string Name {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Propellant))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Propellant_get_Name", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }
    }

    /// <summary>
    /// The propellant ratio.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Propellant_get_Ratio")]
    public float Ratio {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Propellant))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Propellant_get_Ratio", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The total amount of the underlying resource currently reachable given
    /// resource flow rules.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Propellant_get_TotalResourceAvailable")]
    public double TotalResourceAvailable {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Propellant))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Propellant_get_TotalResourceAvailable", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary>
    /// The total vehicle capacity for the underlying propellant resource,
    /// restricted by resource flow rules.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Propellant_get_TotalResourceCapacity")]
    public double TotalResourceCapacity {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Propellant))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Propellant_get_TotalResourceCapacity", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }
}
