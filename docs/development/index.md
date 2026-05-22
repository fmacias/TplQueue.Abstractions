# Development

This section covers local source-build concerns for `TplQueue.Abstractions`.

## Language-version policy

The shipped `netstandard2.0` package line is pinned to `LangVersion=9.0`.

That is a source-build policy for the repository, not a runtime requirement for applications that reference the compiled package.

## Local validation

Run the repository test project directly:

```powershell
dotnet test .\test\Fmacias.TplQueue.Abstractions.Test\Fmacias.TplQueue.Abstractions.Test.csproj
```

Run repository coverage:

```powershell
.\coverage.ps1
.\coverage.ps1 -EnforceBaseline
```

Coverage artifacts are written under `artifacts/coverage/`, while the cross-repository release record is maintained in `..\WorkspaceTplQueue\docs\test-coverage.md`.

## Workspace note

This repository builds standalone.

If `WorkspaceTplQueue` is also cloned, the local `Directory.Build.props` conditionally imports the shared workspace settings without making the workspace mandatory.
