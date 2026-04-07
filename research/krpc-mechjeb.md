# kRPC.MechJeb C# Library Reference

**Documentation**: https://genhis.github.io/KRPC.MechJeb/csharp/
**Version**: 0.7.0
**Namespace**: `KRPC.Client.Services.MechJeb`

This document summarises all capabilities of the kRPC.MechJeb C# library. For exact method signatures, parameter types, and detailed descriptions, consult the online documentation.

**Important notes**:
- All object instances (autopilots, windows, controllers) are permanent until KSP resets — cache and reuse them across flights
- When entering flight scene or switching vessels, **check `APIReady`** before calling other operations
- Credit for method descriptions goes to the MechJeb2 wiki

---

## MechJeb Service (top-level)

Access via `connection.MechJeb()`. All properties are get-only, Flight scene.

| Property | Type | Description |
|---|---|---|
| `APIReady` | `bool` | Whether the MechJeb API is ready to use |
| `AirplaneAutopilot` | `AirplaneAutopilot` | Airplane flight control |
| `AscentAutopilot` | `AscentAutopilot` | Automated launch to orbit |
| `DockingAutopilot` | `DockingAutopilot` | Automated docking |
| `LandingAutopilot` | `LandingAutopilot` | Automated landing |
| `RendezvousAutopilot` | `RendezvousAutopilot` | Automated rendezvous |
| `ManeuverPlanner` | `ManeuverPlanner` | Plan and create manoeuvre nodes |
| `NodeExecutor` | `NodeExecutor` | Execute manoeuvre nodes |
| `SmartASS` | `SmartASS` | Attitude control |
| `SmartRCS` | `SmartRCS` | RCS velocity control |
| `Translatron` | `Translatron` | Throttle/velocity control |
| `StagingController` | `StagingController` | Auto-staging |
| `ThrustController` | `ThrustController` | Throttle limits and management |
| `TargetController` | `TargetController` | Target information and selection |
| `RCSController` | `RCSController` | RCS configuration |
| `AntennaController` | `DeployableController` | Auto-deploy antennas |
| `SolarPanelController` | `DeployableController` | Auto-deploy solar panels |

---

## Autopilots

### AirplaneAutopilot

Controls airplane-style flight with hold modes for altitude, heading, speed, vertical speed, and roll.

| Property | Type | Description |
|---|---|---|
| `Enabled` | `bool` | Enable/disable |
| `AltitudeHoldEnabled` | `bool` | Hold altitude |
| `AltitudeTarget` | `double` | Target altitude |
| `HeadingHoldEnabled` | `bool` | Hold heading |
| `HeadingTarget` | `double` | Target heading |
| `SpeedHoldEnabled` | `bool` | Hold speed |
| `SpeedTarget` | `double` | Target speed |
| `VertSpeedHoldEnabled` | `bool` | Hold vertical speed |
| `VertSpeedTarget` | `double` | Target vertical speed |
| `RollHoldEnabled` | `bool` | Hold roll |
| `RollTarget` | `double` | Target roll |
| `BankAngle` | `double` | Bank angle |

Also exposes PID controller gains (`AccKp/Ki/Kd`, `PitKp/Ki/Kd`, `RolKp/Ki/Kd`, `YawKp/Ki/Kd`) and limits (`PitchDownLimit`, `PitchUpLimit`, `RollLimit`, `YawLimit`).

### AscentAutopilot

Automated launch to orbit with three ascent path profiles.

| Property | Type | Description |
|---|---|---|
| `Enabled` | `bool` | Enable/disable |
| `Status` | `string` | Current status text |
| `DesiredOrbitAltitude` | `double` | Target orbit altitude in km |
| `DesiredInclination` | `double` | Target inclination in degrees |
| `AscentPathIndex` | `int` | 0=Classic, 1=GravityTurn, 2=PVG |
| `AscentPathClassic` | `AscentClassic` | Classic profile settings |
| `AscentPathGT` | `AscentGT` | Gravity turn profile settings |
| `AscentPathPVG` | `AscentPVG` | Primer Vector Guidance settings |
| `ForceRoll` | `bool` | Force roll during ascent |
| `TurnRoll`, `VerticalRoll` | `double` | Roll angles |
| `LimitAoA` | `bool` | Limit angle of attack |
| `MaxAoA` | `double` | Max AoA when limited |
| `AoALimitFadeoutPressure` | `double` | Pressure at which AoA limit deactivates |
| `CorrectiveSteering` | `bool` | Steer based on velocity vector |
| `CorrectiveSteeringGain` | `double` | Gain for corrective steering |
| `Autostage` | `bool` | Auto-stage during ascent |
| `AutodeploySolarPanels` | `bool` | Auto-deploy solar panels |
| `AutoDeployAntennas` | `bool` | Auto-deploy antennas |
| `SkipCircularization` | `bool` | Skip circularization burn |
| `LaunchMode` | `AscentLaunchMode` | Current launch mode (Normal/Rendezvous/TargetPlane) |

**Methods**: `LaunchToRendezvous()`, `LaunchToTargetPlane()`, `AbortTimedLaunch()`

**AscentClassic** profile: `AutoPath`, `AutoTurnPercent`, `AutoTurnSpeedFactor`, turn start/end altitudes and velocities, `TurnEndAngle`, `TurnShapeExponent`

**AscentGT** (Gravity Turn) profile: `TurnStartAltitude`, `TurnStartVelocity`, `TurnStartPitch`, `IntermediateAltitude`, `HoldAPTime`

**AscentPVG** (Primer Vector Guidance) profile: `DesiredApoapsis`, `PitchRate`, `PitchStartVelocity`, `DynamicPressureTrigger`, coast settings, staging trigger settings

### DockingAutopilot

Automated docking with another vessel.

| Property | Type | Description |
|---|---|---|
| `Enabled` | `bool` | Enable/disable |
| `Status` | `string` | Current status |
| `SpeedLimit` | `double` | Max approach speed |
| `ForceRoll` | `bool` | Force roll alignment |
| `Roll` | `double` | Target roll angle |
| `OverrideSafeDistance` | `bool` | Override default safe distance |
| `OverridenSafeDistance` | `double` | Custom safe distance |
| `OverrideTargetSize` | `bool` | Override target size |
| `OverridenTargetSize` | `double` | Custom target size |
| `SafeDistance` | `float` | Computed safe distance (read-only) |
| `TargetSize` | `float` | Computed target size (read-only) |

### LandingAutopilot

Automated landing — targeted or untargeted.

| Property | Type | Description |
|---|---|---|
| `Enabled` | `bool` | Enable/disable |
| `Status` | `string` | Current status |
| `TouchdownSpeed` | `double` | Target touchdown speed |
| `DeployChutes` | `bool` | Auto-deploy parachutes |
| `DeployGears` | `bool` | Auto-deploy landing gear |
| `LimitChutesStage` | `int` | Don't deploy chutes before this stage |
| `LimitGearsStage` | `int` | Don't deploy gear before this stage |
| `RcsAdjustment` | `bool` | Use RCS for fine adjustments |

**Methods**: `LandAtPositionTarget()`, `LandUntargeted()`, `StopLanding()`

### RendezvousAutopilot

Automated rendezvous with a target vessel.

| Property | Type | Description |
|---|---|---|
| `Enabled` | `bool` | Enable/disable |
| `Status` | `string` | Current status |
| `DesiredDistance` | `double` | Target distance from vessel |
| `MaxPhasingOrbits` | `double` | Max orbits to spend phasing |

---

## Windows

### ManeuverPlanner

Creates manoeuvre nodes for various orbital operations. Each operation has specific parameters and a `TimeSelector` for when the manoeuvre should occur.

**Common operation interface**: All operations have `ErrorMessage` (string), `MakeNode()` (deprecated, creates first node), and `MakeNodes()` (creates all necessary nodes). Both throw `OperationException` on failure.

| Operation | Description | Key Parameters |
|---|---|---|
| `OperationApoapsis` | Set new apoapsis | `NewApoapsis`, `TimeSelector` |
| `OperationPeriapsis` | Set new periapsis | `NewPeriapsis`, `TimeSelector` |
| `OperationCircularize` | Circularize orbit | `TimeSelector` (at Pe or Ap) |
| `OperationEllipticize` | Set both Ap and Pe | `NewApoapsis`, `NewPeriapsis`, `TimeSelector` |
| `OperationInclination` | Change inclination | `NewInclination`, `TimeSelector` |
| `OperationLan` | Change longitude of ascending node | `NewLAN`, `TimeSelector` |
| `OperationPlane` | Match planes with target | `TimeSelector` |
| `OperationSemiMajor` | Set semi-major axis | `NewSemiMajorAxis`, `TimeSelector` |
| `OperationTransfer` | Hohmann transfer to target | `SimpleTransfer`, `InterceptOnly`, `PeriodOffset`, `TimeSelector` |
| `OperationInterplanetaryTransfer` | Transfer to another planet | `WaitForPhaseAngle` |
| `OperationCourseCorrection` | Fine-tune approach to target | `CourseCorrectFinalPeA`, `InterceptDistance` |
| `OperationKillRelVel` | Match velocities with target | `TimeSelector` |
| `OperationLambert` | Intercept at chosen time | `InterceptInterval`, `TimeSelector` |
| `OperationLongitude` | Change surface longitude of apsis | `NewSurfaceLongitude`, `TimeSelector` |
| `OperationMoonReturn` | Return from a moon | `MoonReturnAltitude` |
| `OperationResonantOrbit` | For satellite constellations | `ResonanceNumerator`, `ResonanceDenominator`, `TimeSelector` |

#### TimeSelector

Controls when a manoeuvre should occur.

| Property | Type | Description |
|---|---|---|
| `TimeReference` | `TimeReference` | When to perform the manoeuvre |
| `CircularizeAltitude` | `double` | For `TimeReference.Altitude` |
| `LeadTime` | `double` | For `TimeReference.XFromNow` |

**TimeReference enum**: `Computed`, `Apoapsis`, `Periapsis`, `Altitude`, `XFromNow`, `ClosestApproach`, `EqAscending`, `EqDescending`, `EqHighestAd`, `EqNearestAd`, `RelAscending`, `RelDescending`, `RelHighestAd`, `RelNearestAd`

### SmartASS

Vessel attitude/orientation control. Point the vessel in a specific direction.

| Property | Type | Description |
|---|---|---|
| `AutopilotMode` | `SmartASSAutopilotMode` | The active pointing mode |
| `InterfaceMode` | `SmartASSInterfaceMode` | GUI mode (Orbital/Surface/Target/Advanced) |
| `ForceYaw`, `ForcePitch`, `ForceRoll` | `bool` | Enable axis control |
| `SurfaceHeading`, `SurfacePitch`, `SurfaceRoll` | `double` | Surface mode angles |
| `SurfaceVelYaw`, `SurfaceVelPitch`, `SurfaceVelRoll` | `double` | Surface velocity mode angles |
| `AdvancedReference` | `AttitudeReference` | Advanced mode reference frame |
| `AdvancedDirection` | `Direction` | Advanced mode direction |

**Must call `Update(resetPID)` after changing properties** for them to take effect.

**SmartASSAutopilotMode enum**:
- **General**: `Off`, `KillRot`, `Node`, `Advanced`, `Automatic`
- **Orbital**: `Prograde`, `Retrograde`, `NormalPlus`, `NormalMinus`, `RadialPlus`, `RadialMinus`
- **Surface**: `SurfacePrograde`, `SurfaceRetrograde`, `HorizontalPlus`, `HorizontalMinus`, `Surface`, `VerticalPlus`
- **Target**: `TargetPlus`, `TargetMinus`, `RelativePlus`, `RelativeMinus`, `ParallelPlus`, `ParallelMinus`

**AttitudeReference enum**: `Inertial`, `Orbit`, `OrbitHorizontal`, `SurfaceNorth`, `SurfaceVelocity`, `Target`, `RelativeVelocity`, `TargetOrientation`, `ManeuverNode`, `Sun`, `SurfaceHorizontal`

**Direction enum**: `Forward`, `Back`, `Up`, `Down`, `Right`, `Left`

### SmartRCS

RCS-based velocity control.

| Property | Type | Description |
|---|---|---|
| `Mode` | `SmartRCSMode` | Off / ZeroRelativeVelocity / ZeroVelocity |
| `AutoDisableSmartRCS` | `bool` | Auto-disable when done |
| `RCSController` | `RCSController` | RCS settings |

### Translatron

Throttle and velocity management.

| Property | Type | Description |
|---|---|---|
| `Mode` | `TranslatronMode` | Off / KeepOrbital / KeepSurface / KeepVertical |
| `TranslationSpeed` | `double` | Speed to maintain |
| `KillHorizontalSpeed` | `bool` | Kill horizontal velocity |

**Methods**: `PanicSwitch()` — separate all but last stage and activate landing autopilot

**TranslatronMode enum**: `Off`, `KeepOrbital`, `KeepSurface`, `KeepVertical`, `KeepRelative` (internal), `Direct` (internal)

---

## Controllers

### NodeExecutor

Execute manoeuvre nodes automatically.

| Member | Type | Description |
|---|---|---|
| `Enabled` | `bool` | Whether currently executing (read-only) |
| `Autowarp` | `bool` | Auto time-warp to node |
| `LeadTime` | `double` | Seconds to start burn early |
| `Tolerance` | `double` | Delta-v tolerance for completion |
| `ExecuteOneNode()` | method | Execute next manoeuvre node |
| `ExecuteAllNodes()` | method | Execute all manoeuvre nodes |
| `Abort()` | method | Abort execution |

### StagingController

Automated staging when fuel runs out.

| Property | Type | Description |
|---|---|---|
| `Enabled` | `bool` | Enable auto-staging |
| `AutostagingOnce` | `bool` | Auto-disable after one staging event |
| `AutostageLimit` | `int` | Stop staging at this stage number |
| `AutostagePreDelay` | `double` | Delay before staging (seconds) |
| `AutostagePostDelay` | `double` | Delay after staging (seconds) |
| `ClampAutoStageThrustPct` | `double` | Thrust percentage threshold |
| `HotStaging` | `bool` | Enable hot-staging |
| `HotStagingLeadTime` | `double` | Lead time for hot-staging |
| `FairingMinAltitude` | `double` | Min altitude for fairing jettison |
| `FairingMaxDynamicPressure` | `double` | Max Q for fairing jettison |
| `FairingMaxAerothermalFlux` | `double` | Max aerothermal flux for fairing jettison |

### ThrustController

Throttle limits and engine management.

| Property | Type | Description |
|---|---|---|
| `LimitThrottle` | `bool` | Limit max throttle |
| `MaxThrottle` | `double` | Max throttle (0-1) |
| `LimiterMinThrottle` | `bool` | Limit min throttle |
| `MinThrottle` | `double` | Min throttle (0-1) |
| `LimitAcceleration` | `bool` | Limit acceleration |
| `MaxAcceleration` | `double` | Max acceleration (m/s^2) |
| `LimitDynamicPressure` | `bool` | Limit dynamic pressure |
| `MaxDynamicPressure` | `double` | Max Q (Pa) |
| `LimitToPreventFlameout` | `bool` | Prevent jet engine flameout |
| `FlameoutSafetyPct` | `double` | Jet safety margin (0-1) |
| `LimitToPreventOverheats` | `bool` | Prevent overheating |
| `SmoothThrottle` | `bool` | Smooth throttle changes |
| `ThrottleSmoothingTime` | `double` | Smoothing time |
| `DifferentialThrottle` | `bool` | Use differential throttle for torque |
| `DifferentialThrottleStatus` | `DifferentialThrottleStatus` | Current differential throttle status |
| `ElectricThrottle` | `bool` | Throttle based on electric charge |
| `ElectricThrottleLo`, `ElectricThrottleHi` | `double` | Electric charge thresholds |
| `ManageIntakes` | `bool` | Manage air intakes |

### TargetController

Information about and control of the current target.

| Member | Type | Description |
|---|---|---|
| `NormalTargetExists` | `bool` | Whether a vessel/body target exists |
| `PositionTargetExists` | `bool` | Whether a position target exists |
| `TargetOrbit` | `SpaceCenter.Orbit` | Target's orbit |
| `Position` | `Vector3` | Target position |
| `RelativePosition` | `Vector3` | Relative position to target |
| `RelativeVelocity` | `Vector3` | Relative velocity to target |
| `Distance` | `float` | Distance to target |
| `CanAlign` | `bool` | Whether alignment is possible |
| `DockingAxis` | `Vector3` | Docking axis direction |
| `SetPositionTarget(body, lat, lon)` | method | Set a surface position target |
| `SetDirectionTarget(name)` | method | Set a direction target by name |
| `UpdateDirectionTarget(direction)` | method | Update direction target vector |
| `GetPositionTargetPosition()` | method | Get position target coordinates |
| `GetPositionTargetString()` | method | Get position target as string |
| `PickPositionTargetOnMap()` | method | Pick target from map view |

### RCSController

RCS configuration.

| Property | Type | Description |
|---|---|---|
| `RCSForRotation` | `bool` | Use RCS for rotation |
| `RCSThrottle` | `bool` | Use RCS as throttle |

### DeployableController

Used for both solar panels and antennas.

| Member | Type | Description |
|---|---|---|
| `AutoDeploy` | `bool` | Auto-deploy when MechJeb controls vessel |
| `ExtendAll()` | method | Extend all deployable modules |
| `RetractAll()` | method | Retract all deployable modules |
| `AllRetracted()` | method | Check if all are retracted |
