# kOS Reference for Script Conversion

**Documentation**: https://ksp-kos.github.io/KOS/
**Version**: 1.4.0.0

This document summarises kOS (KerboScript) capabilities to help convert kOS scripts into C# kRPC code. For exact syntax details and edge cases, consult the online documentation.

---

## Language Basics

- **Case insensitive** — all identifiers and keywords
- **Statements end with periods** (`.`)
- **Member access uses colons** (`:`) — e.g. `SHIP:ORBIT:APOAPSIS`
- **Late/dynamic typing** — variables have no declared type
- **Comments**: `//` to end of line

### Operators

| kOS | C# Equivalent | Notes |
|---|---|---|
| `=` | `==` | Equality comparison |
| `<>` | `!=` | Not-equal |
| `AND` | `&&` | Logical AND |
| `OR` | `\|\|` | Logical OR |
| `NOT` | `!` | Logical NOT |
| `^` | `Math.Pow()` | Exponentiation |
| `+`, `-`, `*`, `/` | Same | Arithmetic |
| `MOD(a,b)` | `a % b` | Modulus |

---

## Variables and Declarations

| kOS | C# Equivalent |
|---|---|
| `SET x TO value.` | `var x = value;` (or assignment) |
| `LOCAL x IS value.` | `var x = value;` (local scope) |
| `GLOBAL x IS value.` | Field or class-level variable |
| `DECLARE PARAMETER x, y.` | Method parameters |
| `LOCK x TO expr.` | Re-evaluated property or computed value |
| `LOCK STEERING TO expr.` | `vessel.AutoPilot.TargetDirection = ...` (every tick) |
| `LOCK THROTTLE TO expr.` | `vessel.Control.Throttle = ...` (every tick) |
| `TOGGLE x.` | `x = !x;` |
| `x ON.` | `x = true;` |
| `x OFF.` | `x = false;` |

---

## Flow Control

| kOS | C# Equivalent |
|---|---|
| `IF cond { ... } ELSE { ... }` | `if (cond) { ... } else { ... }` |
| `UNTIL cond { ... }` | `while (!cond) { ... }` |
| `FOR item IN list { ... }` | `foreach (var item in list) { ... }` |
| `FROM {init} UNTIL cond STEP {step} DO { ... }` | `for (init; !cond; step) { ... }` |
| `WAIT seconds.` | `Thread.Sleep(ms)` or `spaceCenter.WarpTo(...)` |
| `WAIT UNTIL condition.` | `while (!condition) { Thread.Sleep(100); }` |
| `WHEN cond THEN { ... RETURN true. }` | Background task or polling loop |
| `ON variable { ... RETURN true. }` | Stream callback |
| `BREAK.` | `break;` |
| `CHOOSE a IF cond ELSE b` | `cond ? a : b` |

### Functions

```
// kOS
DECLARE FUNCTION myFunc {
    PARAMETER x, y.
    RETURN x + y.
}

// C# equivalent
double MyFunc(double x, double y) => x + y;
```

---

## Math Functions

**Important**: kOS trigonometry uses **degrees**, not radians.

| kOS | C# Equivalent |
|---|---|
| `SIN(x)` | `Math.Sin(x * Math.PI / 180)` |
| `COS(x)` | `Math.Cos(x * Math.PI / 180)` |
| `TAN(x)` | `Math.Tan(x * Math.PI / 180)` |
| `ARCSIN(x)` | `Math.Asin(x) * 180 / Math.PI` |
| `ARCCOS(x)` | `Math.Acos(x) * 180 / Math.PI` |
| `ARCTAN(x)` | `Math.Atan(x) * 180 / Math.PI` |
| `ARCTAN2(y, x)` | `Math.Atan2(y, x) * 180 / Math.PI` |
| `ABS(x)` | `Math.Abs(x)` |
| `SQRT(x)` | `Math.Sqrt(x)` |
| `ROUND(x)` / `ROUND(x, n)` | `Math.Round(x)` / `Math.Round(x, n)` |
| `CEILING(x)` | `Math.Ceiling(x)` |
| `FLOOR(x)` | `Math.Floor(x)` |
| `LN(x)` | `Math.Log(x)` |
| `LOG10(x)` | `Math.Log10(x)` |
| `MIN(a, b)` | `Math.Min(a, b)` |
| `MAX(a, b)` | `Math.Max(a, b)` |
| `RANDOM()` | `new Random().NextDouble()` |
| `CONSTANT:PI` | `Math.PI` |
| `CONSTANT:E` | `Math.E` |
| `CONSTANT:G` | `6.67384e-11` |
| `CONSTANT:g0` | `9.80655` |
| `CONSTANT:c` | `299792458.0` |

---

## Flight Control

### Cooked Control (high-level steering)

| kOS | kRPC C# Equivalent |
|---|---|
| `LOCK STEERING TO direction.` | Set `AutoPilot.TargetDirection` / `TargetPitchAndHeading()`, call `Engage()` |
| `LOCK THROTTLE TO value.` | Set `Control.Throttle` in a loop |
| `UNLOCK STEERING.` | `AutoPilot.Disengage()` |
| `UNLOCK THROTTLE.` | Stop updating `Control.Throttle` |
| `HEADING(compass, pitch)` | `AutoPilot.TargetPitchAndHeading(pitch, compass)` |

**kOS steering targets map to kRPC**:
- `SHIP:PROGRADE` → `SASMode.Prograde` or compute from `Flight.Prograde`
- `SHIP:RETROGRADE` → `SASMode.Retrograde` or compute from `Flight.Retrograde`
- `Up` → pitch 90 heading 90 (straight up from surface)
- Vector → convert to direction components for AutoPilot

### Raw Control (direct input)

| kOS | kRPC C# Equivalent |
|---|---|
| `SET SHIP:CONTROL:PITCH TO x.` | `Control.Pitch = x` |
| `SET SHIP:CONTROL:YAW TO x.` | `Control.Yaw = x` |
| `SET SHIP:CONTROL:ROLL TO x.` | `Control.Roll = x` |
| `SET SHIP:CONTROL:FORE TO x.` | `Control.Forward = x` |
| `SET SHIP:CONTROL:STARBOARD TO x.` | `Control.Right = x` |
| `SET SHIP:CONTROL:TOP TO x.` | `Control.Up = x` |
| `SET SHIP:CONTROL:MAINTHROTTLE TO x.` | `Control.Throttle = x` |
| `SET SHIP:CONTROL:NEUTRALIZE TO TRUE.` | Set all control axes to 0 |

---

## Vessel Properties

| kOS | kRPC C# Equivalent |
|---|---|
| `SHIP` | `spaceCenter.ActiveVessel` |
| `SHIP:NAME` | `vessel.Name` |
| `SHIP:MASS` | `vessel.Mass` (kg in kRPC, tonnes in kOS) |
| `SHIP:DRYMASS` | `vessel.DryMass` |
| `SHIP:THRUST` | `vessel.Thrust` (Newtons in kRPC, kN in kOS) |
| `SHIP:MAXTHRUST` | `vessel.MaxThrust` |
| `SHIP:AVAILABLETHRUST` | `vessel.AvailableThrust` |
| `SHIP:FACING` | `vessel.Direction(ref)` or `Flight.Direction` |
| `SHIP:STATUS` | `vessel.Situation` (enum, not string) |
| `SHIP:VERTICALSPEED` | `Flight.VerticalSpeed` |
| `SHIP:GROUNDSPEED` | `Flight.HorizontalSpeed` |
| `SHIP:AIRSPEED` | `Flight.TrueAirSpeed` |
| `SHIP:DYNAMICPRESSURE` | `Flight.DynamicPressure` |
| `SHIP:STAGENUM` | `Control.CurrentStage` |
| `SHIP:PARTS` | `vessel.Parts.All` |
| `SHIP:ENGINES` | `vessel.Parts.Engines` |
| `SHIP:RESOURCES` | `vessel.Resources` |
| `SHIP:CREW()` | `vessel.Crew` |
| `SHIP:PARTSNAMED(name)` | `vessel.Parts.WithName(name)` |
| `SHIP:PARTSTAGGED(tag)` | `vessel.Parts.WithTag(tag)` |

**Unit differences**:
- kOS mass is in **tonnes** (metric tons); kRPC mass is in **kg** (multiply kOS by 1000)
- kOS thrust is in **kN**; kRPC thrust is in **Newtons** (multiply kOS by 1000)
- kOS `SHIP:ORBIT:APOAPSIS` is **altitude** above sea level; kRPC has both `Apoapsis` (from body centre) and `ApoapsisAltitude` (above sea level)

---

## Orbit Properties

| kOS | kRPC C# Equivalent |
|---|---|
| `SHIP:ORBIT` / `SHIP:OBT` | `vessel.Orbit` |
| `ORBIT:APOAPSIS` | `Orbit.ApoapsisAltitude` (above sea level) |
| `ORBIT:PERIAPSIS` | `Orbit.PeriapsisAltitude` (above sea level) |
| `ORBIT:BODY` | `Orbit.Body` |
| `ORBIT:PERIOD` | `Orbit.Period` |
| `ORBIT:INCLINATION` | `Orbit.Inclination` (radians in kRPC, degrees in kOS) |
| `ORBIT:ECCENTRICITY` | `Orbit.Eccentricity` |
| `ORBIT:SEMIMAJORAXIS` | `Orbit.SemiMajorAxis` |
| `ORBIT:LAN` | `Orbit.LongitudeOfAscendingNode` (radians in kRPC) |
| `ORBIT:ARGUMENTOFPERIAPSIS` | `Orbit.ArgumentOfPeriapsis` (radians in kRPC) |
| `ORBIT:TRUEANOMALY` | `Orbit.TrueAnomaly` |
| `ORBIT:ETA:APOAPSIS` | `Orbit.TimeToApoapsis` |
| `ORBIT:ETA:PERIAPSIS` | `Orbit.TimeToPeriapsis` |
| `ORBIT:TRANSITION` | `Orbit.NextOrbit` (null if no change) / `Orbit.TimeToSOIChange` |
| `ORBIT:HASNEXTPATCH` | `Orbit.NextOrbit != null` |
| `ORBIT:NEXTPATCH` | `Orbit.NextOrbit` |
| `ORBIT:VELOCITY:ORBIT` | `vessel.Velocity(body.NonRotatingReferenceFrame)` |

**Unit differences**:
- kOS inclination/LAN/argument of periapsis in **degrees**; kRPC in **radians**

---

## Manoeuvre Nodes

| kOS | kRPC C# Equivalent |
|---|---|
| `SET nd TO NODE(ut, radial, normal, prograde).` | `Control.AddNode(ut, prograde, normal, radial)` — **note parameter order differs!** |
| `ADD nd.` | Node is added on creation in kRPC |
| `REMOVE nd.` | `node.Remove()` |
| `NEXTNODE` | `Control.Nodes[0]` (first in list) |
| `HASNODE` | `Control.Nodes.Count > 0` |
| `ALLNODES` | `Control.Nodes` |
| `nd:DELTAV` / `nd:BURNVECTOR` | `node.BurnVector(ref)` or `node.DeltaV` |
| `nd:PROGRADE` | `node.Prograde` |
| `nd:NORMAL` | `node.Normal` |
| `nd:RADIALOUT` | `node.Radial` |
| `nd:ETA` | `node.TimeTo` |
| `nd:TIME` | `node.UT` |
| `nd:ORBIT` | `node.Orbit` |

**Critical difference**: kOS `NODE()` constructor order is `(time, radial, normal, prograde)`, but kRPC `AddNode()` order is `(ut, prograde, normal, radial)`.

---

## Ship Systems

| kOS | kRPC C# Equivalent |
|---|---|
| `SAS ON.` | `Control.SAS = true` |
| `SAS OFF.` | `Control.SAS = false` |
| `RCS ON.` | `Control.RCS = true` |
| `SET SASMODE TO "PROGRADE".` | `Control.SASMode = SASMode.Prograde` |
| `SET NAVMODE TO "ORBIT".` | `Control.SpeedMode = SpeedMode.Orbit` |
| `STAGE.` | `Control.ActivateNextStage()` |
| `LIGHTS ON.` | `Control.Lights = true` |
| `GEAR ON.` | `Control.Gear = true` |
| `BRAKES ON.` | `Control.Brakes = true` |
| `ABORT ON.` | `Control.Abort = true` |
| `AG1 ON.` | `Control.SetActionGroup(1, true)` |
| `PANELS ON.` | `Control.SolarPanels = true` |
| `LEGS ON.` | `Control.Legs = true` |
| `CHUTES ON.` | `Control.Parachutes = true` |
| `SET TARGET TO "name".` | `spaceCenter.TargetVessel = vessel` or `spaceCenter.TargetBody = body` |

---

## Common Conversion Patterns

### Gravity turn / ascent loop
```
// kOS
LOCK STEERING TO HEADING(90, pitch).
LOCK THROTTLE TO 1.
UNTIL APOAPSIS > 80000 {
    SET pitch TO max(0, 90 - ALTITUDE / 1000).
    WAIT 0.1.
}

// C# kRPC
var ap = vessel.AutoPilot;
ap.TargetPitchAndHeading(90, 90);
ap.Engage();
vessel.Control.Throttle = 1;
while (vessel.Orbit.ApoapsisAltitude < 80000)
{
    var pitch = Math.Max(0, 90 - vessel.Flight().MeanAltitude / 1000);
    ap.TargetPitchAndHeading((float)pitch, 90);
    Thread.Sleep(100);
}
```

### Execute manoeuvre node
```
// kOS
SET nd TO NODE(TIME:SECONDS + 60, 0, 0, 100).
ADD nd.
LOCK STEERING TO nd:DELTAV.
WAIT UNTIL VANG(SHIP:FACING:VECTOR, nd:DELTAV) < 2.
LOCK THROTTLE TO 1.
WAIT UNTIL nd:DELTAV:MAG < 0.1.
LOCK THROTTLE TO 0.
UNLOCK STEERING.
REMOVE nd.

// C# kRPC (using MechJeb)
var node = vessel.Control.AddNode(spaceCenter.UT + 60, prograde: 100);
var executor = mj.NodeExecutor;
executor.ExecuteOneNode();
while (executor.Enabled) Thread.Sleep(100);
```

### Wait for altitude
```
// kOS
WAIT UNTIL ALTITUDE > 70000.

// C# kRPC (using streams for efficiency)
var altStream = connection.AddStream(() => vessel.Flight().MeanAltitude);
while (altStream.Get() < 70000)
    Thread.Sleep(100);
altStream.Remove();

// Or using events
var call = Connection.GetCall(() => vessel.Flight().MeanAltitude);
var expr = Expression.GreaterThan(connection,
    Expression.Call(connection, call),
    Expression.ConstantDouble(connection, 70000));
var evnt = krpc.AddEvent(expr);
lock (evnt.Condition) { evnt.Wait(); }
```

---

## Key Gotchas When Converting

1. **Parameter order for nodes**: kOS is `(time, radial, normal, prograde)`, kRPC is `(ut, prograde, normal, radial)`
2. **Units**: kOS uses tonnes/kN; kRPC uses kg/Newtons. kOS angles in degrees; kRPC orbital angles in radians
3. **Altitude**: kOS `APOAPSIS` = altitude above sea level; kRPC has both `Apoapsis` (from body centre) and `ApoapsisAltitude` (from sea level) — use `ApoapsisAltitude` to match kOS behaviour
4. **LOCK STEERING**: In kOS this is re-evaluated every physics tick automatically. In kRPC, you must either use a loop to continuously update `AutoPilot` or use MechJeb's SmartASS
5. **WAIT**: kOS `WAIT` pauses the script but the game continues. In C# use `Thread.Sleep()` — the game also continues since kRPC is external
6. **Triggers**: kOS `WHEN/THEN` and `ON` run in background. In C# use stream callbacks or polling loops
7. **SAS vs AutoPilot**: kOS `LOCK STEERING` disables SAS and uses its own PID controller. kRPC has both `AutoPilot` (kRPC's own PID) and SAS modes via `Control.SAS`/`Control.SASMode`. MechJeb SmartASS is another option
8. **Connection lifecycle**: kRPC `AutoPilot` disengages when client disconnects. kOS scripts persist until rebooted
