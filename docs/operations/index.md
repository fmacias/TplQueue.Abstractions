# Operations

This section groups packaging and release concerns for `TplQueue.Abstractions`.

## Local packaging

Build the local package with:

```powershell
.\pack-local.ps1
```

That writes the preview package into `..\TplQueue.NugetLocal`.

## Package sources

This repository ships with a `NuGet.config` that can work with:

- `..\TplQueue.NugetLocal`
- `https://api.nuget.org/v3/index.json`

Use source enable/disable commands or an override `NuGet.config` when you want to force one source for validation.

## Strong-name signing

Normal source builds are unsigned.

Official signed release packages are produced only when `pack-local.ps1` receives:

- an external private `.snk` path
- the matching full public key

For the coordinated public release path, use the workspace scripts instead of signing this repository in isolation.

## Release flow

The public release flow is coordinated from `WorkspaceTplQueue`:

```powershell
.\pack.ps1 -Version <version> -StrongNameKeyFile <private-key-path> -StrongNamePublicKey <public-key>
.\publish.ps1 -Version <version> -ExpectedStrongNamePublicKey <public-key>
```

The active public preview line is `0.1.0-preview.1`.

## License

`TplQueue.Abstractions` is distributed under the MIT license.
