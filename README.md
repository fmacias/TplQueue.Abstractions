# TplQueue.Abstractions

`TplQueue.Abstractions` is the public contract package for the TplQueue ecosystem.

Use it when you need the shared runtime contracts without taking a dependency on the concrete execution kernel or the adapter implementations.

## Install

```bash
dotnet add package Fmacias.TplQueue.Abstractions --version 0.1.0-preview.1
```

## What this repository owns

The package exposes the shared contracts and reusable models for:

- `IJob`, `IJobRoot`, `IDataJob`, and `IDataJobRoot`
- `IQ`, `IParallelQ`, `IFifoQ`, and `ICacheQ`
- retry-policy contracts and option models
- observer contracts and `IJobEvent`
- payload, serializer, and cache-hydration abstractions

The `TPLQ-V1-015` work established an initial `1.0.0` contract baseline. The current source includes further breaking changes to queue, payload and factory contracts before the stable release; rebuild dependent packages and consumers together. The normalized contract surface is documented in [docs/reference.md](docs/reference.md).

Related repositories:

- `TplQueue.Core` is the published runtime package line, while the source repository remains private and subject to separate approval and license terms
- [TplQueue.Adapter](https://github.com/fmacias/TplQueue.Adapter)
- [TplQueue.Usage](https://github.com/fmacias/TplQueue.Usage)

## Documentation map

Repository-level documentation now lives under [docs/](docs/index.md):

- [Usage](docs/usage/index.md)
- [Development](docs/development/index.md)
- [Operations](docs/operations/index.md)
- [Full reference](docs/reference.md)

## Quick operations

Run the local test surface:

```powershell
dotnet test .\test\Fmacias.TplQueue.Abstractions.Test\Fmacias.TplQueue.Abstractions.Test.csproj
```

Run repository coverage:

```powershell
.\coverage.ps1
.\coverage.ps1 -EnforceBaseline
```

Build a local preview package:

```powershell
.\pack-local.ps1
```

For signed official packaging and public publish flow, use the coordinated workspace scripts documented in [docs/operations/index.md](docs/operations/index.md).

## Public usage repository

For package-consumption samples, public integration tests, and observer-facing validation without private source access, see [TplQueue.Usage](https://github.com/fmacias/TplQueue.Usage).

## License

`TplQueue.Abstractions` is distributed under the MIT license.

Queue configuration may omit the retry-policy name. Null, empty, or whitespace selects NoRetry; a supplied name uses the configured policy lookup.

Observe waiting and executing jobs through `IQ.Subscribe`; `IQ.OnJobEventChanged` has been removed. CacheQ owns a private observer for terminal cache updates.

`WaitAsync` waits for underlying queue work. Cache acknowledgment remains asynchronous, and slow subscribers on the shared observer hub can delay it. CacheQ disposal unsubscribes its observer and can discard pending notifications; completing `WaitAsync` does not guarantee that cache acknowledgment has finished.
