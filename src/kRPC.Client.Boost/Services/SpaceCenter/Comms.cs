using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Used to interact with CommNet for a given vessel.
/// Obtained by calling <see cref="M:SpaceCenter.Vessel.Comms" />.
/// </summary>
public class Comms : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Comms (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Whether the vessel can communicate with KSC.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Comms_get_CanCommunicate")]
    public bool CanCommunicate {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Comms_get_CanCommunicate", _args);
        }
    }

    /// <summary>
    /// Whether the vessel can transmit science data to KSC.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Comms_get_CanTransmitScience")]
    public bool CanTransmitScience {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Comms_get_CanTransmitScience", _args);
        }
    }

    /// <summary>
    /// The communication path used to control the vessel.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Comms_get_ControlPath")]
    public IList<CommLink> ControlPath {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<IList<CommLink>> ("SpaceCenter", "Comms_get_ControlPath", _args);
        }
    }

    /// <summary>
    /// The combined power of all active antennae on the vessel.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Comms_get_Power")]
    public double Power {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Comms_get_Power", _args);
        }
    }

    /// <summary>
    /// Signal delay to KSC in seconds.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Comms_get_SignalDelay")]
    public double SignalDelay {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Comms_get_SignalDelay", _args);
        }
    }

    /// <summary>
    /// Signal strength to KSC.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Comms_get_SignalStrength")]
    public double SignalStrength {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Comms_get_SignalStrength", _args);
        }
    }
}
