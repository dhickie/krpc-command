---
name: krpc-boost-generated-service-migration
description: "Use when migrating generated kRPC C# service client code to kRPC.Client.Boost conventions. Use this skill whenever the user mentions repeating CONTEXT.md updates, generated kRPC service migrations, kRPC.Client.Boost generated services, ConnectionMultiplexer, RemoteObject, RPCAttribute/Rpc cleanup, Encoder/Decode removal, property-to-method conversion, async RPC wrappers, nullable generated RPCs, or Vector3D/Quaternion/Angle conversions for generated kRPC clients, even if they name a service other than SpaceCenter."
---

# kRPC Boost Generated Service Migration

Use this workflow to repeat the SpaceCenter generated-code migration on other generated kRPC services with different service names and procedures.

The goal is not to hand-polish generated code. The goal is to apply the same public-surface and invocation conventions consistently while preserving the generated RPC service/procedure metadata and behavior.

## Start With Scope

If the user has not named the files or service to migrate, ask one short scope question before editing. Do not assume the whole generated tree is in scope.

Useful scope prompts:

- "Which generated service files are in scope for this run?"
- "Should I migrate only `<ServiceName>Service.cs`, its remote object files, and its extension methods, or every generated service file currently present?"

After scope is clear, inspect the current state before changing files. Generated services may be partially migrated, so treat this as an idempotent migration and only apply missing steps.

## Ground Rules

- Preserve service and procedure names exactly from the generated metadata or invocation sites. Do not hard-code `SpaceCenter` except when reading examples.
- Keep changes focused on the scoped generated service files and their directly required support types.
- Prefer short type names plus `using` directives over fully-qualified names for project-local types.
- Do not add compatibility shims just to keep intermediate migration steps building.
- Do not rewrite unrelated manually maintained code unless a support type must change for the scoped generated code.
- Keep generated XML documentation useful. When converting public API shape, update docs at the same time instead of leaving misleading property-style comments.

## Migration Workflow

Apply these steps in order. Running verification after each large layer makes mistakes easier to find.

### 1. Replace Stock kRPC Client Plumbing

For generated remote object classes:

- Inherit from project-local `RemoteObject` instead of `global::KRPC.Client.RemoteObject`.
- Add `using kRPC.Client.Boost.Services;` where needed.
- Change constructors to take `ConnectionMultiplexer connection, ulong id`.
- Call `base(connection, id)`.
- Add `using kRPC.Client.Boost.Connection;` where needed.

For generated service facade classes:

- Store and accept `ConnectionMultiplexer` instead of `global::KRPC.Client.IConnection`.
- Keep the field name already used by the file when possible, commonly `_connection`.
- Update extension methods so they extend `ConnectionMultiplexer` and return the project-local service type.

For generated helper methods on remote object classes:

- Convert non-constructor helper methods that accept `ConnectionMultiplexer connection` into instance methods when they are operating on the remote object instance.
- Remove redundant `connection == null` checks and `<param name="connection">` XML comments.
- Use the inherited `Connection` property for remote object RPC calls.

### 2. Replace RPC Metadata Attributes

- Replace stock `global::KRPC.Client.Attributes.RPCAttribute` references with the project-local `RpcAttribute` or `[Rpc(...)]` shorthand.
- Add `using kRPC.Client.Boost.Attributes;` where needed.
- Preserve the original service and procedure arguments, in the same order.
- Add immediate `[Rpc("Service", "Procedure")]` attributes before generated setter methods as well as getter and normal RPC methods.
- For setters, the procedure in the attribute must match the procedure invoked in the method body, such as `Service_set_Property`.

### 3. Remove Direct Encoder and ByteString Usage

- Do not call `global::KRPC.Client.Encoder.Encode` or `global::KRPC.Client.Encoder.Decode` from generated wrappers.
- Build argument arrays from raw values and pass them to `Invoke`/`InvokeAsync`.
- Use `object[]` for non-nullable arguments and `object?[]` when any argument can be null.
- For return values, call `Invoke<T>(...)` or `InvokeAsync<T>(...)` with the public return type unless a unit/type conversion is required at the boundary.
- For methods with no return value, use non-generic `Invoke(...)` or `InvokeAsync(...)`.
- Remote object generated code should call the inherited `Connection` property; service facade code should call the service field or parameter.

### 4. Convert Generated Properties to Method Pairs

Generated properties should become explicit method pairs:

- Getter property `X` becomes `GetX()`.
- Setter property `X` becomes `SetX(value)`.
- Getter methods keep RPC metadata for the original `get_...` procedure.
- Setter methods get RPC metadata for the original `set_...` procedure.
- Update references in XML docs from converted properties to the corresponding `Get...` method where appropriate.

When splitting XML documentation:

- Getter summaries should read as retrieval docs, typically `Gets ...` or `Returns ...`.
- Setter summaries should describe mutation using the paired getter context, not generic placeholders such as `Sets the X value.`.
- If original docs described both read and write behavior, split them so the getter only describes retrieval and the setter only describes mutation.
- Place XML comments before attributes, not between an attribute and the method declaration.

### 5. Add Async Counterparts

For every generated synchronous RPC wrapper, add an async counterpart unless one already exists:

- Append `Async` to the synchronous method name.
- Return `Task<T>` when the synchronous method returns `T`.
- Return `Task` when the synchronous method returns `void`.
- Mark the method `async` and await `InvokeAsync(...)` or `InvokeAsync<T>(...)`.
- Copy the same `[Rpc(...)]` metadata.
- Copy XML docs and add `Executes asynchronously.` to the summary.
- Add `using System.Threading.Tasks;` where needed.

Async wrappers should not call synchronous `Invoke(...)` methods.

### 6. Apply Nullable Reference Type Corrections

Infer nullability from generated defaults and XML documentation:

- Parameters with `null` defaults should use nullable annotations, such as `SomeRemoteObject? value = null`, `IList<string>? names = null`, or `string? text = ""` when the generated default allows null.
- Methods documented as returning `<c>null</c>` should use nullable public return types.
- Nullable return wrappers should call nullable `Invoke<T?>` / `InvokeAsync<T?>` generic arguments.
- Use `object?[]` for argument arrays that can contain nullable values.

Do not remove nullable markers merely because the RPC transport type is non-nullable internally. The public generated API should reflect documented null behavior.

### 7. Migrate Domain Types Conservatively

Use XML documentation, procedure names, parameter names, and surrounding methods to infer type meaning. Prefer no migration over a misleading migration when the meaning is unclear.

Vector triples:

- Migrate `Tuple<double,double,double>` to `Vector3D` when docs or names clearly describe position, velocity, acceleration, angular velocity, direction, force, torque, impulse, thrust, vector, or delta-v burn vectors.
- Use `Tuple<Vector3D,Vector3D>` for paired force/torque or bounding-box vector values.
- Add `using MathNet.Spatial.Euclidean;` where needed.
- Do not migrate pitch/roll/yaw triples, PID gains, highlight colors, attenuation/deceleration/overshoot/stopping/time-to-peak triples, moment-of-inertia triples, or other non-vector concepts.

Rotations:

- Migrate `Tuple<double,double,double,double>` to `Quaternion` when docs or names clearly describe rotations or orientations.
- Use `Quaternion` from `MathNet.Spatial.Euclidean`.
- Preserve identity defaults by converting tuple defaults to the equivalent `Quaternion` constructor used by the project.

Angles:

- Migrate clear angle values to `Angle` from `MathNet.Spatial.Units`.
- For degree-based RPC values, pass `.Degrees` into RPC args and wrap return values with `Angle.FromDegrees(...)`.
- For radian-based RPC values, pass `.Radians` into RPC args and wrap return values with `Angle.FromRadians(...)`.
- For `float` degree RPC values, cast arguments as `(float)value.Degrees` and convert return values with `Angle.FromDegrees((double)result)` when needed.
- For angle triples that are not geometric vectors, use `Tuple<Angle,Angle,Angle>` and convert each item at the RPC boundary.
- Preserve per-second meaning in XML docs for angular rates, even when the public type is `Angle`.
- Remove explicit degrees/radians wording from docs when the `Angle` type now carries unit semantics, except where rate wording remains important.

### 8. Normalize Generated Formatting

- Remove extra whitespace before method declaration and invocation parentheses.
- Put initializer braces such as `new object[]` and `new object?[]` on their own line.
- Preserve normal control-flow spacing such as `if (...)`.
- Do not churn formatting outside the scoped generated files.

## Verification Checklist

Run focused checks after editing. Adapt paths to the user-supplied scope.

Search for old generated patterns that should be gone from scoped files:

```text
global::KRPC.Client
KRPC.Client.Attributes.RPCAttribute
Encoder.Encode
Encoder.Decode
ByteString
IConnection
systemAlias
genericCollectionsAlias
_Connection
```

Check structural invariants:

- Remote object constructors take `ConnectionMultiplexer connection, ulong id` and call `base(connection, id)`.
- Non-constructor remote object methods no longer accept `ConnectionMultiplexer connection` unless the method genuinely needs an external connection rather than the instance connection.
- There are no leftover generated properties where the selected migration requires method pairs.
- Every generated getter, setter, synchronous RPC wrapper, and async RPC wrapper has an immediate `[Rpc(...)]` attribute with the same procedure name used by the body.
- Every synchronous generated RPC wrapper has an async counterpart, and async bodies use `InvokeAsync` with `await`.
- Nullable public return types use nullable invoke generic arguments.
- Type conversions happen only at the RPC boundary; public method signatures should expose `Vector3D`, `Quaternion`, or `Angle` where the migration selected those types.

Build when feasible:

- Run `dotnet build` after a complete migration layer or before final response.
- Report known pre-existing warnings separately from new errors or warnings.
- If the project is intentionally between migration steps and does not build, report the exact remaining migration blockers instead of hiding them.

## Final Response Format

When done, report:

- Scoped files changed.
- Migration layers completed.
- Verification checks run and their results.
- Build result, including known warnings if present.
- Any conservative decisions left unchanged because docs or names were ambiguous.
