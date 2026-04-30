using System;
using System.Collections.Generic;
using System.Linq;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using BaseCamera = KRPC.Client.Services.SpaceCenter.Camera;

namespace kRPC.Client.Boost.Entities;

/// <summary>
/// Wraps a kRPC SpaceCenter Camera object.
/// </summary>
public class Camera
{
    internal readonly BaseCamera Wrapped;

    internal Camera(BaseCamera camera)
    {
        Wrapped = camera;
    }

    public float DefaultDistance
        => Wrapped.DefaultDistance;

    public float Distance
    {
        get => Wrapped.Distance;
        set => Wrapped.Distance = value;
    }

    public CelestialBody FocussedBody
    {
        get => new CelestialBody(Wrapped.FocussedBody);
        set => Wrapped.FocussedBody = value.Wrapped;
    }

    public Node FocussedNode
    {
        get => new Node(Wrapped.FocussedNode);
        set => Wrapped.FocussedNode = value.Wrapped;
    }

    public Vessel FocussedVessel
    {
        get => new Vessel(Wrapped.FocussedVessel);
        set => Wrapped.FocussedVessel = value.Wrapped;
    }

    public float Heading
    {
        get => Wrapped.Heading;
        set => Wrapped.Heading = value;
    }

    public float MaxDistance
        => Wrapped.MaxDistance;

    public float MaxPitch
        => Wrapped.MaxPitch;

    public float MinDistance
        => Wrapped.MinDistance;

    public float MinPitch
        => Wrapped.MinPitch;

    public CameraMode Mode
    {
        get => Wrapped.Mode;
        set => Wrapped.Mode = value;
    }

    public float Pitch
    {
        get => Wrapped.Pitch;
        set => Wrapped.Pitch = value;
    }
}
