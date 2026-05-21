using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A sensor, such as a thermometer. Obtained by calling <see cref="M:SpaceCenter.Part.Sensor" />.
/// </summary>
public class Sensor : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Sensor (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Whether the sensor is active.
    /// </summary>
    [Rpc ("SpaceCenter", "Sensor_get_Active")]
    public bool Active {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Sensor_get_Active", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Sensor_set_Active", args);
        }
    }

    /// <summary>
    /// The part object for this sensor.
    /// </summary>
    [Rpc ("SpaceCenter", "Sensor_get_Part")]
    public Part Part {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "Sensor_get_Part", args);
        }
    }

    /// <summary>
    /// The current value of the sensor.
    /// </summary>
    [Rpc ("SpaceCenter", "Sensor_get_Value")]
    public string Value {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "Sensor_get_Value", args);
        }
    }
}
