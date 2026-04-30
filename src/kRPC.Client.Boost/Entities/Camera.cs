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
    internal BaseCamera Internal { get; }

    internal Camera(BaseCamera camera)
    {
        Internal = camera;
    }
    public float DefaultDistance
        => Internal.DefaultDistance;
    public float Distance
    {
        get => Internal.Distance;
        set => Internal.Distance = value;
    }
    public CelestialBody FocussedBody
    {
        get => new CelestialBody(Internal.FocussedBody);
        set => Internal.FocussedBody = value.Internal;
    }
    public Node FocussedNode
    {
        get => new Node(Internal.FocussedNode);
        set => Internal.FocussedNode = value.Internal;
    }
    public Vessel FocussedVessel
    {
        get => new Vessel(Internal.FocussedVessel);
        set => Internal.FocussedVessel = value.Internal;
    }
    public float Heading
    {
        get => Internal.Heading;
        set => Internal.Heading = value;
    }
    public float MaxDistance
        => Internal.MaxDistance;
    public float MaxPitch
        => Internal.MaxPitch;
    public float MinDistance
        => Internal.MinDistance;
    public float MinPitch
        => Internal.MinPitch;
    public CameraMode Mode
    {
        get => Internal.Mode;
        set => Internal.Mode = value;
    }
    public float Pitch
    {
        get => Internal.Pitch;
        set => Internal.Pitch = value;
    }
}
