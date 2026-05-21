using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;

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
    [RpcAttribute ("SpaceCenter", "Parachute_Arm")]
    public void Arm ()
    {
        var _args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "Parachute_Arm", _args);
    }

    /// <summary>
    /// Cuts the parachute.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Parachute_Cut")]
    public void Cut ()
    {
        var _args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "Parachute_Cut", _args);
    }

    /// <summary>
    /// Deploys the parachute. This has no effect if the parachute has already
    /// been deployed.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Parachute_Deploy")]
    public void Deploy ()
    {
        var _args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "Parachute_Deploy", _args);
    }

    /// <summary>
    /// Whether the parachute has been armed or deployed.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Parachute_get_Armed")]
    public bool Armed {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Parachute_get_Armed", _args);
        }
    }

    /// <summary>
    /// The altitude at which the parachute will full deploy, in meters.
    /// Only applicable to stock parachutes.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Parachute_get_DeployAltitude")]
    public float DeployAltitude {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Parachute_get_DeployAltitude", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Parachute_set_DeployAltitude", _args);
        }
    }

    /// <summary>
    /// The minimum pressure at which the parachute will semi-deploy, in atmospheres.
    /// Only applicable to stock parachutes.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Parachute_get_DeployMinPressure")]
    public float DeployMinPressure {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Parachute_get_DeployMinPressure", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Parachute_set_DeployMinPressure", _args);
        }
    }

    /// <summary>
    /// Whether the parachute has been deployed.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Parachute_get_Deployed")]
    public bool Deployed {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Parachute_get_Deployed", _args);
        }
    }

    /// <summary>
    /// The part object for this parachute.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Parachute_get_Part")]
    public Part Part {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "Parachute_get_Part", _args);
        }
    }

    /// <summary>
    /// The current state of the parachute.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Parachute_get_State")]
    public ParachuteState State {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<ParachuteState> ("SpaceCenter", "Parachute_get_State", _args);
        }
    }
}
