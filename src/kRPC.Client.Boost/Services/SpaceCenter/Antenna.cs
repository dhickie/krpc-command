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
    [Rpc ("SpaceCenter", "Antenna_Cancel")]
    public void Cancel ()
    {
        var args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "Antenna_Cancel", args);
    }

    /// <summary>
    /// Transmit data.
    /// </summary>
    [Rpc ("SpaceCenter", "Antenna_Transmit")]
    public void Transmit ()
    {
        var args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "Antenna_Transmit", args);
    }

    /// <summary>
    /// Whether partial data transmission is permitted.
    /// </summary>
    [Rpc ("SpaceCenter", "Antenna_get_AllowPartial")]
    public bool AllowPartial {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Antenna_get_AllowPartial", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Antenna_set_AllowPartial", args);
        }
    }

    /// <summary>
    /// Whether data can be transmitted by this antenna.
    /// </summary>
    [Rpc ("SpaceCenter", "Antenna_get_CanTransmit")]
    public bool CanTransmit {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Antenna_get_CanTransmit", args);
        }
    }

    /// <summary>
    /// Whether the antenna can be combined with other antennae on the vessel
    /// to boost the power.
    /// </summary>
    [Rpc ("SpaceCenter", "Antenna_get_Combinable")]
    public bool Combinable {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Antenna_get_Combinable", args);
        }
    }

    /// <summary>
    /// Exponent used to calculate the combined power of multiple antennae on a vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Antenna_get_CombinableExponent")]
    public double CombinableExponent {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Antenna_get_CombinableExponent", args);
        }
    }

    /// <summary>
    /// Whether the antenna is deployable.
    /// </summary>
    [Rpc ("SpaceCenter", "Antenna_get_Deployable")]
    public bool Deployable {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Antenna_get_Deployable", args);
        }
    }

    /// <summary>
    /// Whether the antenna is deployed.
    /// </summary>
    /// <remarks>
    /// Fixed antennas are always deployed.
    /// Returns an error if you try to deploy a fixed antenna.
    /// </remarks>
    [Rpc ("SpaceCenter", "Antenna_get_Deployed")]
    public bool Deployed {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Antenna_get_Deployed", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Antenna_set_Deployed", args);
        }
    }

    /// <summary>
    /// Interval between sending packets in seconds.
    /// </summary>
    [Rpc ("SpaceCenter", "Antenna_get_PacketInterval")]
    public float PacketInterval {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Antenna_get_PacketInterval", args);
        }
    }

    /// <summary>
    /// Units of electric charge consumed per packet sent.
    /// </summary>
    [Rpc ("SpaceCenter", "Antenna_get_PacketResourceCost")]
    public double PacketResourceCost {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Antenna_get_PacketResourceCost", args);
        }
    }

    /// <summary>
    /// Amount of data sent per packet in Mits.
    /// </summary>
    [Rpc ("SpaceCenter", "Antenna_get_PacketSize")]
    public float PacketSize {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Antenna_get_PacketSize", args);
        }
    }

    /// <summary>
    /// The part object for this antenna.
    /// </summary>
    [Rpc ("SpaceCenter", "Antenna_get_Part")]
    public Part Part {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "Antenna_get_Part", args);
        }
    }

    /// <summary>
    /// The power of the antenna.
    /// </summary>
    [Rpc ("SpaceCenter", "Antenna_get_Power")]
    public double Power {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Antenna_get_Power", args);
        }
    }

    /// <summary>
    /// The current state of the antenna.
    /// </summary>
    [Rpc ("SpaceCenter", "Antenna_get_State")]
    public AntennaState State {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<AntennaState> ("SpaceCenter", "Antenna_get_State", args);
        }
    }
}
