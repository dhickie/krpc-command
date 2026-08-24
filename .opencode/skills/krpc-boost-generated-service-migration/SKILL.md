---
name: krpc-boost-generated-service-migration
description: "Use when migrating generated kRPC C# service client code to kRPC.Client.Boost conventions. Use this skill whenever the user mentions repeating CONTEXT.md updates, generated kRPC service migrations, kRPC.Client.Boost generated services, ConnectionMultiplexer/IConnectionMultiplexer, ServiceObject/RemoteObject invoke helpers, RemoteObject constructor access, RPCAttribute/Rpc/GetRpcAttribute/SetRpcAttribute/StaticRpcAttribute cleanup, static RPC metadata, GetRpc public method naming, Encoder/Decode removal, ProcedureArgument arrays, IList-to-List RPC return conversion, collection return types, property-to-method conversion, async RPC wrappers, nullable generated RPCs, XML comment cleanup, see cref namespace fixes, or Vector3D/Quaternion/Angle conversions for generated kRPC clients, even if they name a service other than SpaceCenter."
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
- Change constructors to take `IConnectionMultiplexer connection, ulong id`.
- Mark generated `RemoteObject` constructors that accept `IConnectionMultiplexer` as `internal`, not `public`, so callers cannot directly construct remote object handles with transport internals.
- Call `base(connection, id)`.
- Add `using kRPC.Client.Boost.Connection;` where needed.

For generated service facade classes:

- Store and accept `ConnectionMultiplexer` instead of `global::KRPC.Client.IConnection`.
- Keep the field name already used by the file when possible, commonly `_connection`.
- Update extension methods so they extend `ConnectionMultiplexer` and return the project-local service type.
- If an extension method or generated helper must accept the internal `IConnectionMultiplexer` interface, do not leave that method public; keep its accessibility no wider than the interface it exposes.

For generated helper methods on remote object classes:

- Convert non-constructor helper methods that accept `ConnectionMultiplexer connection` into instance methods when they are operating on the remote object instance.
- Remove redundant `connection == null` checks and `<param name="connection">` XML comments.
- Use the inherited `Connection` property for remote object RPC calls.

### 2. Replace RPC Metadata Attributes

- Replace stock `global::KRPC.Client.Attributes.RPCAttribute` references with the project-local `GetRpcAttribute`, `SetRpcAttribute`, or `StaticRpcAttribute`, normally using `[GetRpc(...)]`, `[SetRpc(...)]`, or `[StaticRpc(...)]` shorthand.
- Do not use the project-local base `RpcAttribute` or `[Rpc(...)]` shorthand in generated service wrappers. It is the shared metadata base; generated RPC wrappers should declare whether the RPC is a read/query, mutation/command, or static procedure.
- Add `using kRPC.Client.Boost.Attributes;` where needed.
- Preserve the original service and procedure arguments, in the same order.
- Use `[GetRpc("Service", "Procedure")]` for functions that fetch, compute, query, or transform values without mutating game state. This includes generated property getters (`get_...` or `_get_...`) and query-style methods such as `Get...`, `Has...`, `Can...`, `With...`, `...At`, `...Position`, `...Velocity`, `Raycast...`, and coordinate transform helpers.
- Use `[SetRpc("Service", "Procedure")]` for functions that set values or send commands. This includes generated property setters (`set_...` or `_set_...`) and action methods such as `Engage`, `Disengage`, `Add...`, `Create...`, `Launch...`, `Load...`, `Quickload`, `Quicksave`, `Save`, `Remove`, `Reset`, `Start`, `Stop`, `Toggle`, `Trigger`, `Undock`, `Decouple`, `Recover`, `Transfer...`, `WarpTo`, and similar commands.
- A `[SetRpc(...)]` method is allowed to return a value when the command creates, starts, or changes something and returns the created object, affected object, transfer handle, or status flag. Examples include adding alarms or waypoints, adding manoeuvre nodes, decoupling/undocking and returning the resulting vessel, starting a resource transfer, and robotic controller commands that return success. Do not reclassify these as `[GetRpc(...)]` solely because the return type is not `void` or `Task`.
- Use `[StaticRpc("Service", "Procedure")]` for procedures whose generated procedure name contains the `_static_` marker, such as `Resources_static_Density` or `ReferenceFrame_static_CreateHybrid`.
- A static RPC may be exposed as an instance method on a remote-object class, but its procedure does not operate on that remote-object instance. Do not add `this` as the first `ProcedureArgument` for static RPCs. Classify based on the generated procedure marker, not on whether the C# wrapper method is declared `static`.
- Replace both `[GetRpc(...)]` and `[SetRpc(...)]` with `[StaticRpc(...)]` for `_static_` procedures; do not preserve getter/command classification for these metadata attributes.
- Add immediate metadata attributes before generated setter methods, getter methods, normal RPC methods, and async counterparts.
- The procedure in the attribute must match the procedure invoked in the method body, such as `Service_get_Property`, `Service_set_Property`, or `Service_Command`.

### 3. Remove Direct Encoder and ByteString Usage

- Do not call `global::KRPC.Client.Encoder.Encode` or `global::KRPC.Client.Encoder.Decode` from generated wrappers.
- Build argument arrays as `ProcedureArgument[]` and pass them to `Invoke`/`InvokeAsync`.
- Put raw argument values directly in `ProcedureArgument[]` initializers whenever an implicit conversion exists.
- For arguments that do not implicitly convert, construct a `ProcedureArgument` explicitly.
- Use `new(value)` for explicit non-null argument values so the runtime type is preserved.
- Use `new(value, typeof(ExpectedType))` only when the argument value can be null or when the procedure contract requires a type different from the runtime value type.
- Do not use `object[]` or `object?[]` argument arrays in generated service wrappers.
- For non-nullable return values, call the inherited `InvokeNonNullable<T>(...)` or `InvokeNonNullableAsync<T>(...)` helper with the non-nullable public return type unless a unit/type conversion is required at the boundary.
- For nullable return values, call the inherited `InvokeNullable<T>(...)` or `InvokeNullableAsync<T>(...)` helper with the non-nullable generic type argument. For example, a public `Part?` return should call `InvokeNullable<Part>(...)`, not `InvokeNullable<Part?>(...)`.
- For methods with no return value, call the inherited `InvokeVoid(...)` or `InvokeVoidAsync(...)` helper.
- Remote object and service facade generated code should use the inherited `ServiceObject`/`RemoteObject` invoke helpers rather than calling `Connection.Invoke...` or `_connection.Invoke...` directly.

Generated collection returns should expose concrete list types:

- For generated RPC wrappers that return `IList<T>`, use `List<T>` as the public return type.
- For async counterparts, use `Task<List<T>>` instead of `Task<IList<T>>`.
- Convert nested list returns recursively, such as `IList<IList<double>>` to `List<List<double>>`.
- Pass the same concrete list type as the invoke helper generic argument, such as `InvokeNonNullable<List<T>>(...)`, `InvokeNonNullableAsync<List<T>>(...)`, `InvokeNullable<List<T>>(...)`, or `InvokeNullableAsync<List<T>>(...)`.
- Apply this to both `[GetRpc(...)]` query wrappers and `[SetRpc(...)]` command wrappers that return collections. A command returning a list, such as staging returning affected vessels, still uses `[SetRpc(...)]`.
- Do not change collection parameters solely because collection returns use `List<T>`. Parameter shape should continue to follow generated defaults and documented nullability unless the user explicitly asks for parameter migration.

### 4. Convert Generated Properties to Method Pairs

Generated properties should become explicit method pairs:

- Getter property `X` becomes `GetX()`.
- Setter property `X` becomes `SetX(value)`.
- Getter methods keep `[GetRpc(...)]` metadata for the original `get_...` procedure.
- Setter methods get `[SetRpc(...)]` metadata for the original `set_...` procedure.
- Update references in XML docs from converted properties to the corresponding `Get...` method where appropriate.

When splitting XML documentation:

- Getter summaries should read as retrieval docs, typically `Gets ...` or `Returns ...`.
- Setter summaries should describe mutation using the paired getter context, not generic placeholders such as `Sets the X value.`.
- If original docs described both read and write behavior, split them so the getter only describes retrieval and the setter only describes mutation.
- Do not leave getter return-value details on setter docs. For example, remove `Returns <c>null</c>...` wording from a setter whose `value` parameter is non-nullable and has no `null` default.
- When XML comments mention null values for parameters, compare the comment to the method signature. If the parameter default is non-null, such as `""`, update the wording to name that default and make the parameter non-nullable unless the generated contract explicitly allows null.
- Place XML comments before attributes, not between an attribute and the method declaration.

### 5. Normalize `GetRpc` Public Method Names

Generated query methods that use `[GetRpc(...)]` should make their value-returning nature obvious at the public API boundary:

- For `[GetRpc(...)]` methods that return a non-boolean value, prefix the public method name with `Get` unless the method is covered by an explicit exception below. Apply the same base name to the async counterpart, with `Async` appended after the new name.
- Do not rename methods that already start with `Get`.
- Do not add `Get` to boolean query methods returning `bool` or `Task<bool>`. Names such as `Has...`, `Can...`, `Is...`, `Active`, `Check...`, or other predicate-style names are clearer without a `Get` prefix.
- Preserve the `[GetRpc(...)]` service and procedure metadata exactly. Rename only the C# wrapper method and any matching XML `cref` references or generated-code call sites in the same scoped Boost client surface.
- Do not rewrite manually maintained application code that still uses stock `KRPC.Client.Services.*` types; those APIs may intentionally keep the original generated names.

SpaceCenter-specific exceptions from the established migration:

- Keep `SpaceCenter.RaycastDistance`, `SpaceCenter.RaycastPart`, `SpaceCenter.TransformDirection`, `SpaceCenter.TransformPosition`, `SpaceCenter.TransformRotation`, and `SpaceCenter.TransformVelocity` without a `Get` prefix because their names describe operations rather than simple value accessors.
- Keep `Flight.SimulateAerodynamicForceAt` without a `Get` prefix for the same reason.

SpaceCenter collection helpers use more descriptive names than a plain `Get` prefix:

- In `Parts`, rename `InDecoupleStage` to `GetPartsInDecoupleStage` and `InDecoupleStageAsync` to `GetPartsInDecoupleStageAsync`.
- In `Parts`, rename `InStage` to `GetPartsInStage` and `InStageAsync` to `GetPartsInStageAsync`.
- In `Parts`, rename `WithModule`, `WithName`, `WithTag`, and `WithTitle` to `GetPartsWithModule`, `GetPartsWithName`, `GetPartsWithTag`, and `GetPartsWithTitle`; apply the same names to async counterparts before `Async`.
- In `Parts`, use the simple rule for `ModulesWithName`: `GetModulesWithName` / `GetModulesWithNameAsync`.
- In `Resources`, rename `WithResource` to `GetResourcesWithName` and `WithResourceAsync` to `GetResourcesWithNameAsync`.

When applying this rule to services other than SpaceCenter, infer equivalent domain-specific collection names conservatively. Prefer a plain `Get` prefix when there is no clear, established domain name.

### 6. Add Async Counterparts

For every generated synchronous RPC wrapper, add an async counterpart unless one already exists:

- Append `Async` to the synchronous method name.
- Return `Task<T>` when the synchronous method returns `T`.
- Return `Task` when the synchronous method returns `void`.
- Mark the method `async` and await `InvokeVoidAsync(...)`, `InvokeNonNullableAsync<T>(...)`, or `InvokeNullableAsync<T>(...)` as appropriate.
- Copy the same `[GetRpc(...)]`, `[SetRpc(...)]`, or `[StaticRpc(...)]` metadata classification as the synchronous wrapper.
- Copy XML docs and add `Executes asynchronously.` to the summary.
- Add `using System.Threading.Tasks;` where needed.

Async wrappers should not call synchronous `Invoke(...)` methods.

### 7. Apply Nullable Reference Type Corrections

Infer nullability from generated defaults and XML documentation:

- Parameters with `null` defaults should use nullable annotations, such as `SomeRemoteObject? value = null`, `IList<string>? names = null`, or `string? text = ""` when the generated default allows null.
- Collection return wrappers use `List<T>`, but collection parameters may remain `IList<T>` when that best reflects the generated parameter contract.
- Parameters with non-null defaults should not be nullable merely because older XML docs mentioned null. Update the XML docs to reflect the actual default value and remove the nullable marker unless the generated contract explicitly allows null.
- Methods documented as returning `<c>null</c>` should use nullable public return types.
- Nullable return wrappers should call `InvokeNullable<T>` / `InvokeNullableAsync<T>` with the non-nullable generic type argument. Non-nullable return wrappers should call `InvokeNonNullable<T>` / `InvokeNonNullableAsync<T>` so unexpected null RPC responses are checked centrally.
- Use `ProcedureArgument[]` for argument arrays, including arrays that contain nullable values. Nullable argument entries that cannot rely on an implicit conversion should be wrapped with `new(value, typeof(ExpectedType))` so null values still carry the procedure contract type.

Do not remove nullable markers merely because the RPC transport type is non-nullable internally. The public generated API should reflect documented null behavior.

### 8. Migrate Domain Types Conservatively

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

Angle conversion metadata:

- When an RPC wrapper converts a numeric angle at the RPC boundary, add `[AngleConversion(AngleType.Degrees/Radians, typeof(float/double))]` immediately before its `[GetRpc(...)]` or `[SetRpc(...)]` attribute.
- Apply `AngleConversion` to both synchronous and asynchronous counterparts. The attribute targets methods, so annotating only one overload leaves test discovery incomplete.
- Add the attribute when a getter converts a server-returned numeric angle into `Angle`, and when any RPC argument converts an `Angle` into `.Degrees` or `.Radians`. This includes setters and command methods.
- Set the `AngleType` value from the actual boundary conversion: `.Degrees` or `Angle.FromDegrees(...)` means `AngleType.Degrees`; `.Radians` or `Angle.FromRadians(...)` means `AngleType.Radians`.
- Set the `angleDataType` argument to the numeric type used at the server boundary (`typeof(float)` or `typeof(double)`), not the public `Angle` type or the RPC's unrelated return type. For input arguments, use the cast or argument expression to determine the type; an uncast `value.Degrees`/`value.Radians` expression is `double`.
- Inspect converted angle collections recursively. For tuples, lists, dictionaries, arrays, sets, and nested combinations, record the numeric element type and annotate the method with that element type. For example, a `Tuple<Angle,Angle,Angle>` backed by `Tuple<double,double,double>` uses `typeof(double)` for both its getter and setter RPC methods.
- If a method has multiple angle arguments, all must use the same metadata because `AngleConversion` stores one unit and numeric type per method. If the arguments use different units or numeric types, identify that limitation rather than applying an inaccurate attribute.
- Distinguish RPC boundary conversions from unrelated application-level `Angle.FromDegrees(...)` or `Angle.FromRadians(...)` calls; only RPC wrappers need this metadata.

### 9. Normalize Generated Formatting

- Remove extra whitespace before method declaration and invocation parentheses.
- Put initializer braces such as `new ProcedureArgument[]` on their own line.
- Preserve normal control-flow spacing such as `if (...)`.
- Do not churn formatting outside the scoped generated files.

### 10. Validate XML Code References

Generated XML docs often contain `<see cref="..." />` references that become stale after classes move namespaces or properties convert to methods:

- Check every changed XML `<see cref="..." />` reference in scoped files, especially `T:` and `M:` references.
- Ensure referenced classes use their current namespace, not the original generated namespace when the type has moved.
- For generated service docs that use old short service references such as `T:SpaceCenter.Part` or `M:SpaceCenter.Vessel.GetParts`, map them to the actual generated namespaces. Top-level service procedures should reference the service facade type, such as `M:kRPC.Client.Boost.Services.SpaceCenter.SpaceCenter.GetActiveVessel`. Remote object procedures and remote object types should reference the remote object namespace, such as `M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Vessel.GetParts` or `T:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Part`.
- Update property references to the converted method names, such as `Get...` or `Set...`, when properties are no longer present.
- Watch for generated members named `Type` that were renamed to avoid `object.GetType()` conflicts. For example, update enum docs from `Vessel.GetType`, `CrewMember.GetType`, or `CommLink.GetType` to the actual wrapper names such as `GetVesselType`, `GetCrewMemberType`, or the generated communication-link type getter.
- Use the correct XML documentation ID prefix. Types use `T:`, methods use `M:`, and enum values/fields use `F:`. Do not leave enum member references such as `RadiatorState.Extended` with an `M:` prefix.
- Prefer accurate references over preserving generated text. If the correct target is ambiguous, leave the wording as plain text rather than adding a misleading cref.

## Verification Checklist

Run focused checks after editing. Adapt paths to the user-supplied scope.

Search for old generated patterns that should be gone from scoped files:

```text
global::KRPC.Client
KRPC.Client.Attributes.RPCAttribute
[Rpc(
Encoder.Encode
Encoder.Decode
ByteString
IConnection
systemAlias
genericCollectionsAlias
_Connection
new object[]
new object?[]
Connection.Invoke
_connection.Invoke
```

Check structural invariants:

- Remote object constructors take `IConnectionMultiplexer connection, ulong id`, are `internal`, and call `base(connection, id)`.
- No generated `RemoteObject` subclass has a public constructor that accepts `IConnectionMultiplexer`.
- Non-constructor remote object methods no longer accept `ConnectionMultiplexer connection` unless the method genuinely needs an external connection rather than the instance connection.
- There are no leftover generated properties where the selected migration requires method pairs.
- Every generated getter, setter, synchronous RPC wrapper, and async RPC wrapper has an immediate `[GetRpc(...)]`, `[SetRpc(...)]`, or `[StaticRpc(...)]` attribute with the same procedure name used by the body.
- Generated property getters (`get_...` or `_get_...`) use `[GetRpc(...)]`; generated property setters (`set_...` or `_set_...`) use `[SetRpc(...)]`.
- Procedures containing `_static_` use `[StaticRpc(...)]`, and their `ProcedureArgument[]` arrays omit `this` as the first entry even when the C# wrapper is an instance method.
- Query/calculation helpers that return values without changing state use `[GetRpc(...)]`, even when their names are not prefixed with `Get`.
- Non-boolean `[GetRpc(...)]` public wrapper names are prefixed with `Get`, except for explicit operation-style exceptions such as SpaceCenter `Raycast...`, SpaceCenter `Transform...`, and `Flight.SimulateAerodynamicForceAt`.
- Boolean `[GetRpc(...)]` wrappers returning `bool` or `Task<bool>` keep predicate-style names such as `Has...`, `Can...`, `Is...`, `Active`, or similar names rather than becoming `Get...`.
- SpaceCenter collection helper names follow the established custom names: `GetPartsInDecoupleStage`, `GetPartsInStage`, `GetPartsWithModule`, `GetPartsWithName`, `GetPartsWithTag`, `GetPartsWithTitle`, and `GetResourcesWithName`, with matching async counterparts.
- Command/mutation helpers use `[SetRpc(...)]`, even when they return a created object, affected object, handle, or status value.
- Search for suspicious mismatches such as `[GetRpc("...", "...set_...")]`, `[SetRpc("...", "...get_...")]`, and command-like names accidentally classified as getters.
- As a sanity check, list `[SetRpc(...)]` methods whose return type is not exactly `void` or `Task`; inspect each result, but treat non-void command returns as acceptable when the RPC semantics are mutation/command-oriented.
- Every synchronous generated RPC wrapper has an async counterpart, and async bodies use the async `ServiceObject`/`RemoteObject` helper with `await`.
- Generated remote objects and service facades call inherited invoke helpers: `InvokeNonNullable*` for non-nullable returns, `InvokeNullable*` for nullable returns, and `InvokeVoid*` for void procedures.
- Nullable public return types use `InvokeNullable<T>` / `InvokeNullableAsync<T>` with non-nullable generic type arguments; non-nullable public return types use `InvokeNonNullable<T>` / `InvokeNonNullableAsync<T>`.
- Generated RPC wrappers do not expose `IList<T>` or `Task<IList<T>>` as public return types; use `List<T>` and `Task<List<T>>` instead.
- Generated nested collection returns use nested concrete lists, such as `List<List<double>>`, not `IList<IList<double>>` or `List<IList<double>>`.
- Generated collection-return invoke helpers use concrete list generic arguments, such as `InvokeNonNullable<List<T>>`, not `InvokeNonNullable<IList<T>>`.
- Generated wrappers use `ProcedureArgument[]` argument arrays, not `object[]` or `object?[]`.
- Explicit `ProcedureArgument` construction uses `new(value)` for non-null values and reserves `new(value, typeof(ExpectedType))` for nullable values or intentionally different contract types.
- Setter XML docs do not describe nullable getter return behavior, and parameter docs mentioning null match the signature default/nullability.
- XML `<see cref="..." />` references point to existing members/types in their current namespaces after the migration.
- No scoped XML docs still reference the old generated documentation namespace, such as `cref="T:SpaceCenter.` or `cref="M:SpaceCenter.` after the types have moved into `kRPC.Client.Boost.Services.<ServiceName>` and its `RemoteObjects` namespace.
- XML documentation IDs use the right kind prefix: `T:` for types, `M:` for methods, and `F:` for enum fields.
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
