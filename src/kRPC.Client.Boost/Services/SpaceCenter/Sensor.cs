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
    public bool GetActive ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Sensor_get_Active", args);
    }

    /// <summary>
    /// Sets the Active value.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetActive (bool value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "Sensor_set_Active", args);
    }

    /// <summary>
    /// The part object for this sensor.
    /// </summary>
    [Rpc ("SpaceCenter", "Sensor_get_Part")]
    public Part GetPart ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Part> ("SpaceCenter", "Sensor_get_Part", args);
    }

    /// <summary>
    /// The current value of the sensor.
    /// </summary>
    [Rpc ("SpaceCenter", "Sensor_get_Value")]
    public string GetValue ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<string> ("SpaceCenter", "Sensor_get_Value", args);
    }
}
