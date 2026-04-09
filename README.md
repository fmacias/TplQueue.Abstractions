# TplQueue.Abstractions

## Sumario
- Operaciones: el empaquetado local es manual via `pack-local.ps1` o `WorkspaceTplQueue\pack.ps1`.
- Operaciones: `NuGet.config` controla el feed local frente a nuget.org segun el entorno.

## Empaquetado local (DevOps)
El empaquetado local es manual via `pack-local.ps1`.
Salida esperada: `.nupkg` y `.snupkg` en `..\TplQueue.NugetLocal`.
Para ejecucion manual: `powershell -NoProfile -ExecutionPolicy Bypass -File .\pack-local.ps1`.

## How to (step by step)
1) Build only (fast loop) from the workspace:
```powershell
..\WorkspaceTplQueue\build.ps1 -Configuration Debug
```

2) Pack this repo explicitly (standalone):
```powershell
.\pack-local.ps1
```

3) Pack all repos in order (workspace):
```powershell
..\WorkspaceTplQueue\pack.ps1
```

## Why this design (justification)
- Keeps Abstractions buildable on its own while supporting a shared workspace.
- Avoids unnecessary packing during edits; packaging is explicit when needed.
- Reduces NuGet cache drift by using a predictable, ordered pack step.

## Local package caching policy
- The local feed `..\TplQueue.NugetLocal` is the source of truth for dev packages.
- Pack scripts force restore to reduce stale cache issues.
- If you still see old types, clear the global cache folder for the package:
  `C:\Users\<user>\.nuget\packages\fmacias.tplqueue.abstractions\1.0.0`

Public contracts and interfaces used across [TplQueue.Core](../TplQueue.Core) and 
[TplQueue.Adapters](../TplQueue.Adapter) related components. 

## Workspace solution (optional)
This repo builds standalone. If you also clone the umbrella 
workspace `WorkspaceTplQueue`, this repo will automatically import 
the shared `Directory.Build.props` from `..\\WorkspaceTplQueue\\Directory.Build.props` via 
its local `Directory.Build.props`.
The import is conditional; if the workspace folder is not present, 
nothing changes.

## NuGet packaging

This solution has been configured to generate the NuGet 
package at parent directory TplQueue.NugetLocal as you 
can see in [NuGet.config](./NuGet.config) configuration.

The package `Fmacias.TplQueue.Abstractions` is created only when `pack-local.ps1`
is executed manually (or via `WorkspaceTplQueue\pack.ps1`).

## Switch between local and nuget.org sources

The [NuGet.config](./NuGet.config) file defines both the local feed and
nuget.org. To switch which one is used for restores, either enable/disable
the source or edit the file.

Option A: enable/disable sources
```powershell
dotnet nuget list source
dotnet nuget disable source LocalPackages
dotnet nuget enable source nuget.org
```

To switch back to the local folder:
```powershell
dotnet nuget enable source LocalPackages
dotnet nuget disable source nuget.org
```

Option B: edit `NuGet.config`
```xml
<packageSources>
  <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
  <add key="LocalPackages" value="..\\TplQueue.NugetLocal" />
</packageSources>
```
Remove or comment the source you do not want active.

## Publish a new version to NuGet.org

1) Update the version in `src/Fmacias.TplQueue.Abstractions.csproj`
   (for example, set `<PackageVersion>1.2.3</PackageVersion>`).
2) Pack the release build:
```powershell
dotnet pack .\Fmacias.TplQueue.Abstractions.sln -c Release -o ..\TplQueue.NugetLocal -p:SkipPackLocal=true
```
3) Push the package to NuGet.org:
```powershell
dotnet nuget push ..\TplQueue.NugetLocal\Fmacias.TplQueue.Abstractions.1.2.3.nupkg `
  --source https://api.nuget.org/v3/index.json `
  --api-key <YOUR_NUGET_API_KEY>
```

## Payload handler roadmap

Current state:

- `IPayload.PayloadId` is the single stable persisted handler key for hydrated payload jobs
- `IPayloadHandlers` resolves public `IHandler` implementations only by that stable string key
- plugin-style registration is exposed through `IPayloadHandlerPlugin` and `IPayloadHandlerRegistry`
- handler classes can be composed from the application layer or an IoC container through handler factories

Next step:

- add optional higher-level plugin discovery helpers on top of the key-based registration contract
- document recommended handler-key versioning conventions for long-lived cached payloads

## Visual Studio session note
Avoid opening `WorkspaceTplQueue.sln` and any `TplQueue.*.sln` in separate VS sessions at the same time. The workspace swaps to project references, while standalone solutions stay package-based, and running both can lead to confusing dependency views or build output conflicts.


