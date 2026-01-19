# TplQueue.Abstractions

## Sumario
- Operaciones: el build de la solucion ejecuta `pack-local.ps1` y deja paquetes en `..\TplQueue.NugetLocal`.
- Operaciones: `NuGet.config` controla el feed local frente a nuget.org segun el entorno.

## Empaquetado local (DevOps)
El empaquetado local se dispara desde `Directory.Build.targets`, que llama a `pack-local.ps1` despues del build.
Salida esperada: `.nupkg` y `.snupkg` en `..\TplQueue.NugetLocal`.
Para ejecucion manual: `powershell -NoProfile -ExecutionPolicy Bypass -File .\pack-local.ps1`.
Para omitir: `SkipPackLocal=true`.

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

The construction of the package `Fmacias.TplQueue.Abstractions` 
occurs after solution building. 
```xml
<Project>
  <Target Name="PackLocalAfterSolutionBuild" AfterTargets="Build" ...
...
</Project>
```
Check `Project.Target.Exec` element 
of [Directory.Build.targets](./Directory.Build.targets). Notice that
the `Powershell` command file [pack-local.ps1](./pack-local.ps1) is being
invoked

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

## Visual Studio session note
Avoid opening `WorkspaceTplQueue.sln` and any `TplQueue.*.sln` in separate VS sessions at the same time. The workspace swaps to project references, while standalone solutions stay package-based, and running both can lead to confusing dependency views or build output conflicts.


