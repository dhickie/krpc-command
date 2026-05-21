using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using System;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A light. Obtained by calling <see cref="M:SpaceCenter.Part.Light" />.
/// </summary>
public class Light : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Light (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Whether the light is switched on.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Light_get_Active")]
    public bool Active {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Light_get_Active", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Light_set_Active", args);
        }
    }

    /// <summary>
    /// Whether blinking is enabled.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Light_get_Blink")]
    public bool Blink {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Light_get_Blink", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Light_set_Blink", args);
        }
    }

    /// <summary>
    /// The blink rate of the light.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Light_get_BlinkRate")]
    public float BlinkRate {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Light_get_BlinkRate", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Light_set_BlinkRate", args);
        }
    }

    /// <summary>
    /// The color of the light, as an RGB triple.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Light_get_Color")]
    public Tuple<float,float,float> Color {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<float,float,float>> ("SpaceCenter", "Light_get_Color", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Light_set_Color", args);
        }
    }

    /// <summary>
    /// The part object for this light.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Light_get_Part")]
    public Part Part {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "Light_get_Part", args);
        }
    }

    /// <summary>
    /// The current power usage, in units of charge per second.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Light_get_PowerUsage")]
    public float PowerUsage {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Light_get_PowerUsage", args);
        }
    }
}
