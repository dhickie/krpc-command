using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using Google.Protobuf;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A parachute. Obtained by calling <see cref="M:SpaceCenter.Part.Parachute" />.
/// </summary>
public class Parachute : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Parachute (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Deploys the parachute. This has no effect if the parachute has already
    /// been armed or deployed.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parachute_Arm")]
    public void Arm ()
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parachute))
        };
        connection.Invoke ("SpaceCenter", "Parachute_Arm", _args);
    }

    /// <summary>
    /// Cuts the parachute.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parachute_Cut")]
    public void Cut ()
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parachute))
        };
        connection.Invoke ("SpaceCenter", "Parachute_Cut", _args);
    }

    /// <summary>
    /// Deploys the parachute. This has no effect if the parachute has already
    /// been deployed.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parachute_Deploy")]
    public void Deploy ()
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parachute))
        };
        connection.Invoke ("SpaceCenter", "Parachute_Deploy", _args);
    }

    /// <summary>
    /// Whether the parachute has been armed or deployed.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parachute_get_Armed")]
    public bool Armed {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parachute))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parachute_get_Armed", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// The altitude at which the parachute will full deploy, in meters.
    /// Only applicable to stock parachutes.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parachute_get_DeployAltitude")]
    public float DeployAltitude {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parachute))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parachute_get_DeployAltitude", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parachute)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "Parachute_set_DeployAltitude", _args);
        }
    }

    /// <summary>
    /// The minimum pressure at which the parachute will semi-deploy, in atmospheres.
    /// Only applicable to stock parachutes.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parachute_get_DeployMinPressure")]
    public float DeployMinPressure {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parachute))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parachute_get_DeployMinPressure", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parachute)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "Parachute_set_DeployMinPressure", _args);
        }
    }

    /// <summary>
    /// Whether the parachute has been deployed.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parachute_get_Deployed")]
    public bool Deployed {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parachute))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parachute_get_Deployed", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// The part object for this parachute.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parachute_get_Part")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Part Part {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parachute))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parachute_get_Part", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part), connection);
        }
    }

    /// <summary>
    /// The current state of the parachute.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parachute_get_State")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.ParachuteState State {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parachute))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parachute_get_State", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.ParachuteState)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ParachuteState), connection);
        }
    }
}
