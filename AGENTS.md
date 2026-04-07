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
  Program.cs  # The entry point of application
  UI/         # Contains all code related to rendering the UI and reacting to input
  Manoeuvres/ # Contains definitions of all manoeuvres that can be executed
```

Each manoeuvre has a separate file under the `Manoeuvres` folder.