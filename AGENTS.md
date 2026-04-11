# Agent instructions

This repository contains a console application that is used to automate manoeuvre, procedures and missions in the game Kerbal Space Program.

It does this using a selection of mods:

- **kRPC** - Creates a server inside the game which external programs can communicate with over a network, automating anything you can do with a vessel in the game
- **MechJeb2** - An autopilot mod that can automate some manoeuvre in the game through an in-game user interface
- **kRPC.MechJeb** - A mod that adds an integration layer between MechJeb and kRPC, allowing applications communicating with the kRPC server to invoke MechJeb autopilot actions

The console application itself is "mission control" - it orchestrates the automation of the vessel by executing automated manoeuvres.

## Mod documentation

kRPC and kRPC.MechJeb both expose C# packages for applications to use.

The documentation for these packages can be found at:

- kRPC - https://krpc.github.io/krpc/csharp.html
- kRPC.MechJeb - https://genhis.github.io/KRPC.MechJeb/csharp/

This documentation should be used as the source of truth for what is possible using these mods.

At times, you may be provided with scripts written for a different automation mod called kOS, in order to convert these into C# code for krpc-command. When interpresting kOS scripts, the [kOS documentation](https://ksp-kos.github.io/KOS/) should be used in order to parse and understand them.

## Method of operation

kRPC exposes an API that allows client applications to render UI elements within the game. When krpc-command runs, it connects to the kRPC server, and creates a window in the UI for the user to interact with.

This UI allows the user to select a manoeuvre to perform. When they select a manoeuvre, the window then changes to a configuration window for that specific manoeuvre, allowing the user to specify any required parameters.

When the user is happy with the parameters of the manoeuvre and clicks a button to execute it, the manoeuvre should then be executed.

While a manoeuvre is in progress, logs are shown in the UI indicating the step currently being executed and the manoeuvre's progress. It can be cancelled at any time by pressing a cancel button in the UI.

## Technology

The console application should run using .NET 10.

## Code structure

The code should be compartmentalised according to function:

```
src/
  Program.cs           # The entry point of the application
  UI/                  # All code related to rendering the UI and reacting to input
  Manoeuvres/          # Definitions of all manoeuvres that can be executed
    Parameters/        # Manoeuvre parameter type hierarchy
  Extensions/          # Extension methods for third-party APIs (e.g. MechJeb)
```

Each manoeuvre has a separate file under the `Manoeuvres` folder.

## Code style and conventions

- Use modern C# features where appropriate, including primary constructors and file-scoped namespaces.
- Never use `null!` to satisfy nullability checks. Fields should be properly initialized in the constructor.
- Do not use fully-qualified type names when a `using` directive for the namespace is already in scope.
- Avoid stringly-typed values. Use proper types that represent the data (e.g. `bool` not `string` for a boolean parameter).
- Do not leave dead code in the codebase, such as unused properties, unreachable statements, or methods that are never called.
- All public methods and properties should have XML doc comments.

## Architecture and design patterns

### Dependency injection via constructors

Manoeuvres receive `ManoeuvreLogger` and `ManoeuvreContext` through constructor injection (using primary constructors), not as parameters to `ExecuteAsync`. Similarly, `ManoeuvreLogger` receives its notification callback via its constructor, not through events.

### No two-phase initialization

Objects should be fully usable immediately after construction. Do not use separate `Initialise()` or `Setup()` methods that must be called after the constructor.

### Reflection-based manoeuvre registration

`Program.cs` discovers `IManoeuvre` implementors via reflection. New manoeuvres should not be manually added to a list — they are automatically found when the assembly is scanned.

### Manoeuvre parameter hierarchy

Parameters use a class hierarchy with an abstract `ManoeuvreParameter` base class and concrete subclasses for each type (e.g. `BoolManoeuvreParameter`) in the `Parameters/` folder. Do not use open generics with `typeof(T)` branching to handle different types.

### Extension methods for reusable MechJeb operations

Common MechJeb patterns, such as waiting for API readiness or executing a manoeuvre node, should be implemented as extension methods in `Extensions/MechJebExtensions.cs` rather than inlined in each manoeuvre.

### Manoeuvre method structure

Keep `ExecuteAsync` focused on high-level orchestration. Extract implementation details (e.g. creating a manoeuvre node) into private methods.

### Events should not carry unused data

If an event or callback's subscribers do not need a payload, use `Action` rather than `Action<T>`.

## API usage

Always verify kRPC and kRPC.MechJeb method names and signatures against the official documentation before using them. Do not guess or assume API names.