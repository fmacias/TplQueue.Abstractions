# TplQueue.Abstractions
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
