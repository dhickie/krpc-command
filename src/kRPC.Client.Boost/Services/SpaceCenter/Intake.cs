using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// An air intake. Obtained by calling <see cref="M:SpaceCenter.Part.Intake" />.
/// </summary>
public class Intake : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Intake (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// The area of the intake's opening, in square meters.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Intake_get_Area")]
    public float Area {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Intake_get_Area", args);
        }
    }

    /// <summary>
    /// The rate of flow into the intake, in units of resource per second.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Intake_get_Flow")]
    public float Flow {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Intake_get_Flow", args);
        }
    }

    /// <summary>
    /// Whether the intake is open.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Intake_get_Open")]
    public bool Open {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Intake_get_Open", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Intake_set_Open", args);
        }
    }

    /// <summary>
    /// The part object for this intake.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Intake_get_Part")]
    public Part Part {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "Intake_get_Part", args);
        }
    }

    /// <summary>
    /// Speed of the flow into the intake, in <math>m/s</math>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Intake_get_Speed")]
    public float Speed {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Intake_get_Speed", args);
        }
    }
}
