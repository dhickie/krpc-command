using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// An antenna. Obtained by calling <see cref="M:SpaceCenter.Part.Antenna" />.
/// </summary>
public class Antenna : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Antenna (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Cancel current transmission of data.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Antenna_Cancel")]
    public void Cancel ()
    {
        var _args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "Antenna_Cancel", _args);
    }

    /// <summary>
    /// Transmit data.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Antenna_Transmit")]
    public void Transmit ()
    {
        var _args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "Antenna_Transmit", _args);
    }

    /// <summary>
    /// Whether partial data transmission is permitted.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Antenna_get_AllowPartial")]
    public bool AllowPartial {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Antenna_get_AllowPartial", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Antenna_set_AllowPartial", _args);
        }
    }

    /// <summary>
    /// Whether data can be transmitted by this antenna.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Antenna_get_CanTransmit")]
    public bool CanTransmit {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Antenna_get_CanTransmit", _args);
        }
    }

    /// <summary>
    /// Whether the antenna can be combined with other antennae on the vessel
    /// to boost the power.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Antenna_get_Combinable")]
    public bool Combinable {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Antenna_get_Combinable", _args);
        }
    }

    /// <summary>
    /// Exponent used to calculate the combined power of multiple antennae on a vessel.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Antenna_get_CombinableExponent")]
    public double CombinableExponent {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Antenna_get_CombinableExponent", _args);
        }
    }

    /// <summary>
    /// Whether the antenna is deployable.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Antenna_get_Deployable")]
    public bool Deployable {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Antenna_get_Deployable", _args);
        }
    }

    /// <summary>
    /// Whether the antenna is deployed.
    /// </summary>
    /// <remarks>
    /// Fixed antennas are always deployed.
    /// Returns an error if you try to deploy a fixed antenna.
    /// </remarks>
    [RpcAttribute ("SpaceCenter", "Antenna_get_Deployed")]
    public bool Deployed {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Antenna_get_Deployed", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Antenna_set_Deployed", _args);
        }
    }

    /// <summary>
    /// Interval between sending packets in seconds.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Antenna_get_PacketInterval")]
    public float PacketInterval {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Antenna_get_PacketInterval", _args);
        }
    }

    /// <summary>
    /// Units of electric charge consumed per packet sent.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Antenna_get_PacketResourceCost")]
    public double PacketResourceCost {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Antenna_get_PacketResourceCost", _args);
        }
    }

    /// <summary>
    /// Amount of data sent per packet in Mits.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Antenna_get_PacketSize")]
    public float PacketSize {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Antenna_get_PacketSize", _args);
        }
    }

    /// <summary>
    /// The part object for this antenna.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Antenna_get_Part")]
    public Part Part {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "Antenna_get_Part", _args);
        }
    }

    /// <summary>
    /// The power of the antenna.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Antenna_get_Power")]
    public double Power {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Antenna_get_Power", _args);
        }
    }

    /// <summary>
    /// The current state of the antenna.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Antenna_get_State")]
    public AntennaState State {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<AntennaState> ("SpaceCenter", "Antenna_get_State", _args);
        }
    }
}
