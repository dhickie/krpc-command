using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A landing leg. Obtained by calling <see cref="M:SpaceCenter.Part.Leg" />.
/// </summary>
public class Leg : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Leg (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Whether the leg is deployable.
    /// </summary>
    [Rpc ("SpaceCenter", "Leg_get_Deployable")]
    public bool Deployable {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Leg_get_Deployable", args);
        }
    }

    /// <summary>
    /// Whether the landing leg is deployed.
    /// </summary>
    /// <remarks>
    /// Fixed landing legs are always deployed.
    /// Returns an error if you try to deploy fixed landing gear.
    /// </remarks>
    [Rpc ("SpaceCenter", "Leg_get_Deployed")]
    public bool Deployed {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Leg_get_Deployed", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Leg_set_Deployed", args);
        }
    }

    /// <summary>
    /// Returns whether the leg is touching the ground.
    /// </summary>
    [Rpc ("SpaceCenter", "Leg_get_IsGrounded")]
    public bool IsGrounded {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Leg_get_IsGrounded", args);
        }
    }

    /// <summary>
    /// The part object for this landing leg.
    /// </summary>
    [Rpc ("SpaceCenter", "Leg_get_Part")]
    public Part Part {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "Leg_get_Part", args);
        }
    }

    /// <summary>
    /// The current state of the landing leg.
    /// </summary>
    [Rpc ("SpaceCenter", "Leg_get_State")]
    public LegState State {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<LegState> ("SpaceCenter", "Leg_get_State", args);
        }
    }
}
