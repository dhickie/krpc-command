# kRPC C# Library Reference

**Documentation**: https://krpc.github.io/krpc/csharp.html
**Version**: 0.5.4
**NuGet Package**: `KRPC.Client` (also requires `Google.Protobuf`)
**Namespace**: `KRPC.Client` (client), `KRPC.Client.Services.*` (service APIs)

This document summarises all capabilities of the kRPC C# library. For exact method signatures, parameter types, and detailed descriptions, consult the online documentation.

---

## Client Connection

### Connection (`KRPC.Client.Connection`)

The primary entry point. All interaction with the kRPC server goes through this object.

- **Constructor**: `new Connection(name, address, rpcPort, streamPort)` — defaults to `127.0.0.1:50000/50001`
- **Disposable**: Must be disposed when finished (use `using` block or call `Dispose()`)
- **Service access**: Call extension methods like `connection.SpaceCenter()`, `connection.KRPC()`, `connection.UI()` to get service instances

### Streams (`Stream<T>`)

Efficiently receive continuously-updated data from the server without repeated request/response overhead.

- **Create**: `connection.AddStream(() => someMethod())` — pass a lambda expression
- **Read**: `stream.Get()` — returns the most recent value
- **Rate control**: `stream.Rate` — set update frequency in Hz (0 = unlimited)
- **Condition variables**: `stream.Condition` — notified via `Monitor.PulseAll` on value change
- **Wait**: `stream.Wait(timeout)` — blocks until value changes (must hold lock on `stream.Condition`)
- **Callbacks**: `stream.AddCallback(value => ...)` — invoked on value change (may be called from different thread)
- **Remove**: `stream.Remove()` — stops and removes the stream
- All streams auto-stop when client disconnects

### Events (`Event`)

Wait for specific conditions. Built on top of streams.

- **Wait**: `event.Wait(timeout)` — blocks until event fires
- **Callbacks**: `event.AddCallback(() => ...)` — invoked when event fires
- **Custom events**: Build server-side expressions using `Expression` API, then `krpc.AddEvent(expr)`

### Procedure Calls

- `Connection.GetCall(() => method())` — returns a `ProcedureCall` message object for use with expressions/events

---

## KRPC Service (`KRPC.Client.Services.KRPC`)

Server management and meta-operations.

- **GetStatus()** — server version, etc.
- **AddEvent(Expression)** — create custom events using server-side expression trees
- **Expression API** — build boolean/arithmetic/comparison expressions that execute on the server:
  - `Expression.ConstantDouble`, `Expression.ConstantFloat`, `Expression.ConstantInt`, `Expression.ConstantBool`, `Expression.ConstantString`
  - `Expression.Call` — wrap a procedure call
  - `Expression.Equal`, `Expression.NotEqual`, `Expression.GreaterThan`, `Expression.LessThan`, `Expression.GreaterThanOrEqual`, `Expression.LessThanOrEqual`
  - `Expression.And`, `Expression.Or`, `Expression.ExclusiveOr`, `Expression.Not`
  - `Expression.Add`, `Expression.Subtract`, `Expression.Multiply`, `Expression.Divide`, `Expression.Modulo`, `Expression.Power`
  - `Expression.LeftShift`, `Expression.RightShift`
  - `Expression.Cast` — type conversion
  - `Expression.ToList`, `Expression.ToSet`, `Expression.Count`, `Expression.Sum`, `Expression.Max`, `Expression.Min`, `Expression.Average`, `Expression.Select`, `Expression.Where`, `Expression.Contains`, `Expression.Aggregate`, `Expression.OrderBy`
  - `Expression.CreateTuple`, `Expression.CreateList`, `Expression.CreateSet`, `Expression.CreateDictionary`
  - `Expression.Get` — access tuple/list/dictionary items
  - `Expression.Invoke` — call a function expression

---

## SpaceCenter Service (`KRPC.Client.Services.SpaceCenter`)

The core service for interacting with KSP. Provides access to vessels, celestial bodies, orbits, controls, and more.

### SpaceCenter (top-level)

| Capability | Description |
|---|---|
| **Active vessel** | `ActiveVessel` (get/set) — the currently controlled vessel |
| **All vessels** | `Vessels` — list of all vessels in the game |
| **Celestial bodies** | `Bodies` — dictionary of all bodies keyed by name |
| **Targeting** | `TargetBody`, `TargetVessel`, `TargetDockingPort`, `ClearTarget()` |
| **Time** | `UT` (universal time in seconds), `G` (gravitational constant) |
| **Time warp** | `WarpMode`, `WarpRate`, `WarpFactor`, `RailsWarpFactor` (get/set), `PhysicsWarpFactor` (get/set), `MaximumRailsWarpFactor`, `CanRailsWarpAt(factor)`, `WarpTo(ut, maxRailsRate, maxPhysicsRate)` |
| **Save/Load** | `Save(name)`, `Load(name)`, `Quicksave()`, `Quickload()`, `CanRevertToLaunch()`, `RevertToLaunch()` |
| **Launch vessels** | `LaunchableVessels(dir)`, `LaunchVessel(...)`, `LaunchVesselFromVAB(name)`, `LaunchVesselFromSPH(name)` |
| **Coordinate transforms** | `TransformPosition(...)`, `TransformDirection(...)`, `TransformRotation(...)`, `TransformVelocity(...)` |
| **Raycasting** | `RaycastDistance(...)`, `RaycastPart(...)` |
| **UI** | `UIVisible`, `Navball` |
| **Career** | `Science`, `Funds`, `Reputation`, `GameMode` |
| **Other** | `Camera`, `WaypointManager`, `ContractManager`, `AlarmManager`, `FARAvailable`, `CreateKerbal(...)`, `GetKerbal(name)`, `LoadSpaceCenter()`, `Screenshot(...)` |

### Vessel

Interact with vessels — get orbital/flight data, manipulate controls, manage resources.

| Capability | Description |
|---|---|
| **Identity** | `Name` (get/set), `Type` (get/set), `Situation`, `Biome`, `MET` |
| **Recovery** | `Recoverable`, `Recover()` |
| **Flight data** | `Flight(referenceFrame)` — returns `Flight` object with telemetry |
| **Orbit** | `Orbit` — returns `Orbit` object with orbital parameters |
| **Controls** | `Control` — throttle, staging, SAS, RCS, action groups, manoeuvre nodes |
| **Autopilot** | `AutoPilot` — point vessel in a direction, set pitch/heading/roll |
| **Communications** | `Comms` — CommNet interaction |
| **Parts** | `Parts` — access all parts by type, name, tag, stage |
| **Resources** | `Resources`, `ResourcesInDecoupleStage(stage, cumulative)` |
| **Crew** | `CrewCapacity`, `CrewCount`, `Crew` |
| **Physics** | `Mass`, `DryMass`, `Thrust`, `AvailableThrust`, `MaxThrust`, `MaxVacuumThrust`, `SpecificImpulse`, `VacuumSpecificImpulse`, `KerbinSeaLevelSpecificImpulse`, `MomentOfInertia`, `InertiaTensor` |
| **Torque** | `AvailableTorque`, `AvailableReactionWheelTorque`, `AvailableRCSTorque`, `AvailableRCSForce`, `AvailableEngineTorque`, `AvailableControlSurfaceTorque`, `AvailableOtherTorque` |
| **Reference frames** | `ReferenceFrame` (vessel-fixed), `OrbitalReferenceFrame`, `SurfaceReferenceFrame`, `SurfaceVelocityReferenceFrame` |
| **Position/velocity** | `Position(ref)`, `Velocity(ref)`, `Rotation(ref)`, `Direction(ref)`, `AngularVelocity(ref)`, `BoundingBox(ref)` |

**Enums**: `VesselType` (Base, Debris, Lander, Plane, Probe, Relay, Rover, Ship, Station, etc.), `VesselSituation` (Docked, Escaping, Flying, Landed, Orbiting, PreLaunch, Splashed, SubOrbital)

### Flight

Telemetry data for a vessel in a given reference frame. Obtained via `Vessel.Flight(referenceFrame)`.

| Category | Properties |
|---|---|
| **Altitude** | `MeanAltitude`, `SurfaceAltitude`, `BedrockAltitude`, `Elevation` |
| **Position** | `Latitude`, `Longitude`, `CenterOfMass` |
| **Speed** | `Speed`, `HorizontalSpeed`, `VerticalSpeed`, `Velocity` |
| **Orientation** | `Pitch`, `Heading`, `Roll`, `Direction`, `Rotation` |
| **Orbital directions** | `Prograde`, `Retrograde`, `Normal`, `AntiNormal`, `Radial`, `AntiRadial` |
| **Atmosphere** | `AtmosphereDensity`, `DynamicPressure`, `StaticPressure`, `StaticPressureAtMSL` |
| **Aerodynamics** | `AerodynamicForce`, `Lift`, `Drag`, `SimulateAerodynamicForceAt(...)`, `SpeedOfSound`, `Mach`, `TrueAirSpeed`, `EquivalentAirSpeed`, `TerminalVelocity`, `AngleOfAttack`, `SideslipAngle` |
| **Temperature** | `TotalAirTemperature`, `StaticAirTemperature` |
| **G-force** | `GForce` |
| **FAR-only** | `ReynoldsNumber`, `StallFraction`, `DragCoefficient`, `LiftCoefficient`, `BallisticCoefficient`, `ThrustSpecificFuelConsumption` |

### Orbit

Orbital parameters for a vessel or celestial body.

| Category | Properties |
|---|---|
| **Shape** | `Apoapsis`, `Periapsis`, `ApoapsisAltitude`, `PeriapsisAltitude`, `SemiMajorAxis`, `SemiMinorAxis`, `Eccentricity` |
| **Orientation** | `Inclination`, `LongitudeOfAscendingNode`, `ArgumentOfPeriapsis` |
| **Current state** | `Radius`, `Speed`, `OrbitalSpeed` |
| **Timing** | `Period`, `TimeToApoapsis`, `TimeToPeriapsis`, `TimeToSOIChange` |
| **Anomalies** | `TrueAnomaly`, `MeanAnomaly`, `EccentricAnomaly`, `MeanAnomalyAtEpoch`, `Epoch` |
| **Prediction at time** | `RadiusAt(ut)`, `PositionAt(ut, ref)`, `OrbitalSpeedAt(time)`, `MeanAnomalyAtUT(ut)`, `EccentricAnomalyAtUT(ut)`, `TrueAnomalyAtUT(ut)` |
| **Anomaly conversion** | `TrueAnomalyAtRadius(radius)`, `UTAtTrueAnomaly(ta)`, `RadiusAtTrueAnomaly(ta)` |
| **Relative to target** | `TrueAnomalyAtAN(target)`, `TrueAnomalyAtDN(target)`, `RelativeInclination(target)`, `TimeOfClosestApproach(target)`, `DistanceAtClosestApproach(target)`, `ListClosestApproaches(target, orbits)` |
| **Patched conics** | `NextOrbit`, `Body` |
| **Reference plane** | `ReferencePlaneNormal(conn, ref)`, `ReferencePlaneDirection(conn, ref)` (static methods) |

### Control

Manipulate vessel controls — throttle, rotation, staging, SAS/RCS, action groups, manoeuvre nodes.

| Category | Properties/Methods |
|---|---|
| **Throttle** | `Throttle` (0-1) |
| **Rotation** | `Pitch`, `Yaw`, `Roll` (-1 to 1) |
| **Translation** | `Forward`, `Up`, `Right` (-1 to 1) |
| **Wheels** | `WheelThrottle`, `WheelSteering` (-1 to 1) |
| **Custom axes** | `CustomAxis01` through `CustomAxis04` (-1 to 1) |
| **Systems** | `SAS` (bool), `SASMode` (enum), `RCS` (bool), `ReactionWheels` (bool), `Gear` (bool), `Legs` (bool), `Wheels` (bool), `Lights` (bool), `Brakes` (bool), `Antennas` (bool), `CargoBays` (bool), `Intakes` (bool), `Parachutes` (bool), `Radiators` (bool), `ResourceHarvesters` (bool), `ResourceHarvestersActive` (bool), `SolarPanels` (bool), `Abort` (bool) |
| **Staging** | `CurrentStage`, `ActivateNextStage()`, `StageLock` (bool) |
| **Action groups** | `GetActionGroup(group)`, `SetActionGroup(group, state)`, `ToggleActionGroup(group)` |
| **Manoeuvre nodes** | `AddNode(ut, prograde, normal, radial)`, `Nodes` (list), `RemoveNodes()` |
| **Input mode** | `InputMode` — Additive (default, adds to vessel inputs) or Override (replaces inputs) |
| **State** | `Source` (Kerbal/Probe/None), `State` (Full/Partial/None), `SpeedMode` (Orbit/Surface/Target) |

**SASMode enum**: StabilityAssist, Maneuver, Prograde, Retrograde, Normal, AntiNormal, Radial, AntiRadial, Target, AntiTarget

### Node (Manoeuvre Node)

Created via `Control.AddNode(ut, prograde, normal, radial)`.

| Property | Description |
|---|---|
| `Prograde`, `Normal`, `Radial` | Delta-v components (get/set) |
| `DeltaV` | Total delta-v (get/set, does NOT change during execution) |
| `RemainingDeltaV` | Remaining delta-v (changes during execution) |
| `BurnVector(ref)`, `RemainingBurnVector(ref)` | Direction + magnitude vectors |
| `UT` (get/set), `TimeTo` | When the node occurs |
| `Orbit` | Resulting orbit after executing the node |
| `ReferenceFrame`, `OrbitalReferenceFrame` | Reference frames at node position |
| `Position(ref)`, `Direction(ref)` | Node position and direction |
| `Remove()` | Delete the node |

### AutoPilot

Point the vessel in a specific direction. Obtained via `Vessel.AutoPilot`.

| Method/Property | Description |
|---|---|
| `Engage()` / `Disengage()` | Start/stop autopilot |
| `Wait()` | Block until vessel reaches target direction |
| `TargetPitch`, `TargetHeading` | Target angles (degrees) |
| `TargetRoll` | Target roll (NaN for none) |
| `TargetDirection` | Direction vector in reference frame |
| `TargetPitchAndHeading(pitch, heading)` | Set both at once |
| `ReferenceFrame` | Reference frame for target direction |
| `Error`, `PitchError`, `HeadingError`, `RollError` | Current pointing errors |
| `SAS`, `SASMode` | SAS control (equivalent to Control.SAS) |
| **Tuning** | `RollThreshold`, `StoppingTime`, `DecelerationTime`, `AttenuationAngle`, `AutoTune`, `TimeToPeak`, `Overshoot`, `PitchPIDGains`, `RollPIDGains`, `YawPIDGains` |

**Note**: Auto-pilot disengages when the client disconnects. Cannot use a reference frame that rotates with the controlled vessel.

### CelestialBody

Represents planets, moons, and stars.

| Category | Properties |
|---|---|
| **Identity** | `Name`, `Satellites`, `IsStar`, `HasSolidSurface` |
| **Orbit** | `Orbit` (its own orbit around parent body) |
| **Physical** | `Mass`, `GravitationalParameter`, `SurfaceGravity`, `EquatorialRadius`, `SphereOfInfluence` |
| **Rotation** | `RotationalPeriod`, `RotationalSpeed`, `RotationAngle`, `InitialRotation` |
| **Atmosphere** | `HasAtmosphere`, `AtmosphereDepth`, `HasAtmosphericOxygen`, `DensityAt(altitude)`, `PressureAt(altitude)`, `AtmosphericDensityAtPosition(pos, ref)`, `TemperatureAt(pos, ref)` |
| **Surface** | `SurfaceHeight(lat, lon)`, `BedrockHeight(lat, lon)`, `MSLPosition(lat, lon, ref)`, `SurfacePosition(lat, lon, ref)`, `BedrockPosition(lat, lon, ref)`, `PositionAtAltitude(lat, lon, alt, ref)` |
| **Coordinate conversion** | `AltitudeAtPosition(pos, ref)`, `LatitudeAtPosition(pos, ref)`, `LongitudeAtPosition(pos, ref)` |
| **Biomes** | `Biomes` (set of names), `BiomeAt(lat, lon)` |
| **Science** | `FlyingHighAltitudeThreshold`, `SpaceHighAltitudeThreshold` |
| **Reference frames** | `ReferenceFrame` (rotates with body), `NonRotatingReferenceFrame`, `OrbitalReferenceFrame` |
| **Position/velocity** | `Position(ref)`, `Velocity(ref)`, `Rotation(ref)`, `Direction(ref)`, `AngularVelocity(ref)` |

### Parts

Access vessel parts by type, name, tag, module, or stage. Obtained via `Vessel.Parts`.

**Querying**: `All`, `Root`, `Controlling` (get/set), `WithName(name)`, `WithTitle(title)`, `WithTag(tag)`, `WithModule(moduleName)`, `InStage(stage)`, `InDecoupleStage(stage)`, `ModulesWithName(moduleName)`

**Typed part lists**: `Antennas`, `CargoBays`, `ControlSurfaces`, `Decouplers`, `DockingPorts`, `Engines`, `Experiments`, `Fairings`, `Intakes`, `Legs`, `LaunchClamps`, `Lights`, `Parachutes`, `Radiators`, `ResourceDrains`, `RCS`, `ReactionWheels`, `ResourceConverters`, `ResourceHarvesters`, `RoboticHinges`, `RoboticPistons`, `RoboticRotations`, `RoboticRotors`, `Sensors`, `SolarPanels`, `Wheels`

**Part class**: Each part provides access to its specific typed module (e.g. `part.Engine`, `part.Decoupler`), physical properties (mass, temperature, impact tolerance), parent/child relationships, stage info, reference frame, and a generic `Modules` list.

**Module class**: Generic access to any KSP PartModule's fields, events, and actions — useful for interacting with modded parts or stock modules not directly exposed by kRPC.

**Key part types** (each with specific properties):
- **Engine**: `Active`, `Thrust`, `AvailableThrust`, `MaxThrust`, `ThrustLimit`, `SpecificImpulse`, `HasFuel`, `Gimballed`, `GimbalRange`, `GimbalLocked`, `GimbalLimit`, `Throttle`, `ThrottleLocked`, `IndependentThrottle`, `CanRestart`, `CanShutdown`, modes, propellants
- **Decoupler**: `Decouple()`, `Decoupled`, `Staged`, `Impulse`, `IsOmniDecoupler`, `AttachedPart`
- **DockingPort**: `Undock()`, `State`, `DockedPart`, `HasShield`, `Shielded`, rotation control, reference frame
- **Parachute**: `Deploy()`, `Arm()`, `Cut()`, `State`, `DeployAltitude`, `DeployMinPressure`
- **SolarPanel**: `Deployed`, `State`, `EnergyFlow`, `SunExposure`
- **Antenna**: `Transmit()`, `Cancel()`, `State`, `Deployed`, `Power`, `CanTransmit`
- **Fairing**: `Jettison()`, `Jettisoned`
- **Experiment**: `Run()`, `Transmit()`, `Dump()`, `Reset()`, `HasData`, `Data`, `Available`

### Resources

Access resource information for a vessel, stage, or part.

- `Names` — list of resource names
- `HasResource(name)`, `Amount(name)`, `Max(name)`
- `All` — list of individual `Resource` objects
- `Density(conn, name)` (static), `FlowMode(conn, name)` (static)
- `ResourceTransfer.Start(conn, fromPart, toPart, resource, maxAmount)` — transfer resources between parts

### ReferenceFrame

Used for positions, rotations, and velocities throughout the API. No readable properties — only used as a parameter.

- `CreateRelative(conn, ref, position, rotation, velocity, angularVelocity)` — offset from parent frame
- `CreateHybrid(conn, positionRef, rotationRef, velocityRef, angularVelocityRef)` — combine components from different frames

**Common reference frames**:
- `Vessel.ReferenceFrame` — vessel-fixed, axes aligned with vessel (x=right, y=forward, z=bottom)
- `Vessel.OrbitalReferenceFrame` — vessel-fixed, axes aligned with prograde/normal/radial
- `Vessel.SurfaceReferenceFrame` — vessel-fixed, axes aligned with north/up/east
- `Vessel.SurfaceVelocityReferenceFrame` — vessel-fixed, y-axis aligned with surface velocity
- `CelestialBody.ReferenceFrame` — body-fixed, rotates with body
- `CelestialBody.NonRotatingReferenceFrame` — body-centred, does not rotate
- `CelestialBody.OrbitalReferenceFrame` — body-centred, orbital prograde/normal/radial

---

## User Interface Service (`KRPC.Client.Services.UI`)

Create in-game UI elements. This is the API used by krpc-command to render its control window.

### UI (top-level)

- `StockCanvas` — the built-in game canvas
- `AddCanvas()` — create a new canvas
- `Message(content, duration, position, color, size)` — display on-screen message
- `Clear(clientOnly)` — remove all UI elements

### Canvas

Container for UI elements. Has `RectTransform`, `Visible`.

- `AddPanel(visible)` — create a container panel
- `AddText(content, visible)` — add a text label
- `AddInputField(visible)` — add a text input
- `AddButton(content, visible)` — add a clickable button
- `Remove()` — remove the canvas

### Panel

Container that can hold other UI elements. Same methods as Canvas (`AddPanel`, `AddText`, `AddInputField`, `AddButton`, `Remove`).

### Text

A text label with styling options.

- `Content` (get/set), `Font`, `Size`, `Style` (Normal/Bold/Italic/BoldAndItalic), `Color` (RGB tuple), `Alignment` (TextAnchor enum), `LineSpacing`, `AvailableFonts`

### Button

A clickable button.

- `Text` — the `Text` object for styling
- `Clicked` (get/set) — whether button was clicked; reset to `false` to detect next click

### InputField

A text input field.

- `Value` (get/set) — current text
- `Text` — `Text` object for styling
- `Changed` (get/set) — whether value changed; reset to `false` to detect next change

### RectTransform

Controls position, size, and layout of UI elements (Unity RectTransform).

- `Position`, `LocalPosition`, `Size`, `UpperRight`, `LowerLeft`
- `Anchor` (set), `AnchorMax`, `AnchorMin`, `Pivot`
- `Rotation` (quaternion), `Scale`

---

## Drawing Service (`KRPC.Client.Services.Drawing`)

Draw 3D objects in the game world for debugging/visualization.

- `AddLine(start, end, ref, visible)` — draw a line
- `AddPolygon(vertices, ref, visible)` — draw a polygon
- `AddText(text, ref, position, rotation, visible)` — draw 3D text
- `Clear(clientOnly)` — remove all drawn objects

Each drawable has properties for colour, thickness/size, material, and reference frame.

---

## Other Mod Services

kRPC also provides C# APIs for other mods (if installed):

- **InfernalRobotics** — control robotic servos and servo groups
- **Kerbal Alarm Clock** — create and manage alarms
- **RemoteTech** — antenna/communications management
- **LiDAR** — laser distance measurement
- **Docking Camera** — camera images from docking ports
