# TplQueue.Abstractions

`TplQueue.Abstractions` provides the public contracts and shared models for the TplQueue ecosystem. Use this package when you need to reference jobs, job roots, queues, retry-policy contracts, observer contracts, payload contracts, serializer contracts, or cache-related abstractions without taking a dependency on the concrete runtime implementations.

It is the common contract layer consumed by [TplQueue.Core](https://github.com/fmacias/TplQueue.Core/blob/main/README.md) and the integration modules in [TplQueue.Adapter](https://github.com/fmacias/TplQueue.Adapter/blob/main/README.md).

## Table of contents

- [Summary](#summary)
- [Install](#install)
- [Package contents](#package-contents)
- [C# language-version policy](#c-language-version-policy)
- [Retry policy factory contract](#retry-policy-factory-contract)
- [Defaults namespace policy](#defaults-namespace-policy)
- [Cache hydration contracts](#cache-hydration-contracts)
- [Payload handler contracts](#payload-handler-contracts)
- [Serializer public surface decision](#serializer-public-surface-decision)
- [Serializer and cache usage shape](#serializer-and-cache-usage-shape)
- [Runtime type resolution status](#runtime-type-resolution-status)
- [Workspace solution (optional)](#workspace-solution-optional)
- [NuGet packaging](#nuget-packaging)
- [Strong-name signing](#strong-name-signing)
- [License](#license)
- [Switch between local and nuget.org sources](#switch-between-local-and-nugetorg-sources)
- [Publish a new version to NuGet.org](#publish-a-new-version-to-nugetorg)
- [Payload handler contract status](#payload-handler-contract-status)

## Summary

Choose `Fmacias.TplQueue.Abstractions` when you want a stable contract package for:

- `IJob`, `IJobRoot`, `IDataJob`, and `IDataJobRoot`
- `IParallelQ`, `IFifoQ`, and `ICacheQ`
- retry-policy contracts and related option models
- observer contracts and `IJobEvent`
- payload, serializer, and cache-hydration abstractions

This package is intended for application code, integration packages, and extension libraries that need the TplQueue public API surface without carrying the execution kernel or adapter implementations.

## Install

Install from NuGet:

```bash
dotnet add package Fmacias.TplQueue.Abstractions --version 0.1.0-preview.1
```

Or reference it directly in a project file:

```xml
<PackageReference Include="Fmacias.TplQueue.Abstractions" Version="0.1.0-preview.1" />
```

## Package contents

The package includes the core contracts and reusable models that the rest of the TplQueue line builds on:

- job graph contracts and public factory-facing abstractions
- queue contracts for bounded parallel, FIFO, and cache-backed flows
- retry-policy contracts and option models
- observer and event contracts for diagnostics and monitoring
- payload, serializer, and cache-hydration contracts

## C# language-version policy

The shipped `netstandard2.0` package line is pinned to `LangVersion=9.0`.

This is a source-build policy for TplQueue itself, not a runtime requirement for applications that reference the compiled package. Consumers targeting classic `.NET Framework` or any other runtime that can reference `netstandard2.0` assemblies do not need to raise their own project `LangVersion` only to consume `Fmacias.TplQueue.Abstractions`.

`9.0` is the intentional floor because it preserves the current nullable-aware source style and the small amount of C# 9 syntax already used in the product code, while removing the accidental long-term dependency on `LangVersion=latest`. If you build this repository from source, use a .NET SDK that supports C# 9 or later.

## Retry policy factory contract

`IRetryPolicyAbstractFactory` supports two usage styles:

- non-generic lookup through `PolicyByName(...)`, where missing names fall back to `NoRetryPolicy`
- typed lookup through `PolicyByName<T>(...)` and `GetPolicy<T>()`, where the default adapter maps built-in retry policy interfaces to their implementations

The built-in retry policy interfaces supported by the default adapter are:

- `INoRetryPolicy`
- `ILinearBackoff`
- `IExponentialBackoff`

Custom retry policies should be requested by concrete type. The concrete custom policy must implement `IRetryPolicy` and expose a public parameterless constructor so the adapter can instantiate it. Custom interfaces are not resolved automatically unless a future registration mechanism is introduced.

## Defaults namespace policy

`Fmacias.TplQueue.Defaults` contains reusable default artifacts intended to simplify
implementation across the TplQueue ecosystem, including code that lives outside the
public API composition boundary.

This namespace is acceptable for:

- immutable default values and option builders
- stateless helper classes
- logging metadata and precompiled logging delegates such as `Fmacias.TplQueue.Defaults.Log`
- small reusable objects that do not retain or mutate shared process state

This namespace is not a place for:

- global services
- service locators
- mutable static state
- process-wide caches or registries with internal state
- static classes that coordinate runtime behavior by storing shared data

> [!NOTE]
> **Acceptance rule:** a type under `Fmacias.TplQueue.Defaults` is acceptable only when it does not change global state, does not retain mutable shared state, and exists to keep associated services in the TplQueue ecosystem simpler and more consistent

If a component needs to keep state, coordinate runtime behavior, or own process-wide
resources, it should stay behind a normal service abstraction and explicit composition,
not under `Fmacias.TplQueue.Defaults`.

## Cache hydration contracts

Payload-aware cache hydration is intentionally split into two responsibilities:

- `ITypeResolver` resolves the persisted payload CLR type name into a `System.Type`.
- `IUniversalDataSerializer` serializes and deserializes payload data once that `Type` is known.
- `IRuntimeNodeTypeResolver` specializes `ITypeResolver` for runtime/AppDomain-based resolution.
- `IRuntimeNodeTypeResolverFactory` exposes the default runtime-oriented resolver factory contract used by the adapter cache modules.

The adapter cache flow is:

1. `JobNodeDto` persists `PayloadTypeName` from the payload CLR type, together with the serialized payload content.
2. `ITypeResolver.Resolve(string payloadTypeName)` turns the stored type name back into a CLR `Type`.
3. `IUniversalDataSerializer.Deserialize(string json, Type type)` materializes the payload instance. The `json` parameter name is retained for compatibility; the value is serializer-specific payload content.

This separation keeps serialization concerns independent from runtime type lookup, which is useful for cache hydration, plugin loading, and future whitelist-based resolvers.

## Payload handler contracts

`IPayload.PayloadId` is the stable persisted handler key for payload-aware jobs. Keep it stable across deployments for any payload type that can be dehydrated into a cache and hydrated later.

Recommended key style:

```text
<domain>.<operation>/v<version>
```

Example:

```csharp
public sealed class MeasurementPayload : IPayload
{
    public const string HandlerKey = "measurements.persist/v1";

    public string SensorId { get; set; } = string.Empty;
    public double Value { get; set; }
    public string PayloadId => HandlerKey;
    public DateTime CollectionTime => DateTime.UtcNow;
}
```

`IApi.RegisterPayloadHandler(...)` is the public adapter-facing registration path. Cache hydration resolves `IPayload.PayloadId` through the API-owned internal handler registry, not through a caller-built handler collection.

## Serializer public surface decision

`IUniversalDataSerializer` remains the shared serializer contract used by cache hydration and payload graph reconstruction. Concrete serializer modules may expose narrower factory contracts, but cache-facing APIs should continue to accept `IUniversalDataSerializer`.

The approved XML serializer surface is:

- `IXmlSerializerFactory` for creating XML serializer instances
- `IXmlUniversalSerializer : IUniversalDataSerializer` as the XML-specific serializer marker contract
- `IApi.XmlSerializerFactory()` on the adapter facade
- `Fmacias.TplQueue.Serialization.Xml` as the adapter module that contains the concrete XML implementation

The current serializer scope is JSON and XML only. Do not add serializer plugin discovery, serializer registries, or external serializer dependencies as part of this scope.

Existing JSON-oriented public names such as `IUniversalDataSerializer.Deserialize(string json, Type type)` and persisted members such as `PayloadJson` remain compatibility concerns and should not be renamed as part of XML serializer support. Treat `PayloadJson` as the legacy storage member for serializer-specific payload content.

`SystemTexSerializerFactory()` is also retained for compatibility. New code should prefer the correctly spelled `SystemTextSerializerFactory()` facade member.

When a custom resolution boundary is needed, reuse `TypeDeserializer.TryResolveType(...)` from `Fmacias.TplQueue.Defaults` inside your own `ITypeResolver` implementation.

## Serializer and cache usage shape

Concrete serializer implementations live in [TplQueue.Adapter](https://github.com/fmacias/TplQueue.Adapter/blob/main/README.md), but they are consumed through the contracts defined here:

```csharp
IUniversalDataSerializer jsonSerializer =
    api.SystemTextSerializerFactory().Serializer();

IUniversalDataSerializer xmlSerializer =
    api.XmlSerializerFactory().Serializer();
```

The same serializer contract is passed into cache creation. The common facade path uses the adapter-owned default runtime resolver:

```csharp
IMemCache cache = api.Cache<IMemCache>(
    MemCacheFactory.Create(),
    jsonSerializer);
```

Keep the explicit resolver overload when a custom resolution boundary is required:

```csharp
ITypeResolver typeResolver =
    RuntimeNodeTypeResolverFactory.Create().Resolver();

IMemCache cache = api.Cache<IMemCache>(
    MemCacheFactory.Create(),
    jsonSerializer,
    typeResolver);
```

After hydration, the cache returns an `IDataJobRoot`, which is dispatched through the normal queue contract:

```csharp
if (cache.TryHydrateNextJob(out IDataJobRoot hydratedRoot, out ICacheEntry lease))
{
    ILogger<IParallelQ> logger = loggerFactory.CreateLogger<IParallelQ>();
    IParallelQ queue = api.QFactory.Parallel("main", logger);

    queue.Enqueue(hydratedRoot, CancellationToken.None);
    queue.ResumePolling();

    await hydratedRoot.WaitUntilFinishedAsync();
}
```

Use the XML serializer in the same cache flow when XML payload storage is desired; the cache still depends only on `IUniversalDataSerializer`.

## Runtime type resolution status

Current state:

- `IRuntimeNodeTypeResolver` is intentionally AppDomain-based for compatibility with the current adapter implementation.
- The current contract is suitable for simple runtime probing and legacy-oriented hosting scenarios.

Deferred work:

- modern .NET plugin loading and unloadable isolation boundaries should use an `AssemblyLoadContext`-oriented resolver when that becomes a real requirement
- keep `ITypeResolver` as the abstraction boundary so runtime loading can evolve without coupling it to `IUniversalDataSerializer`

## Workspace solution (optional)

This repository builds standalone. If you also clone the umbrella workspace `WorkspaceTplQueue`, this repository automatically imports the shared `Directory.Build.props` from `..\WorkspaceTplQueue\Directory.Build.props` via its local `Directory.Build.props`.

The import is conditional. If the workspace folder is not present, nothing changes.

## NuGet packaging

This solution is configured to write NuGet packages to the parent `TplQueue.NugetLocal` folder, as defined in [NuGet.config](./NuGet.config).

The package `Fmacias.TplQueue.Abstractions` is created only when `pack-local.ps1` is executed manually, or when it is invoked through `WorkspaceTplQueue\pack.ps1`.

## Strong-name signing

**Source builds are unsigned by default. This is intentional.**

**Official TplQueue release builds are strong-named only when `pack-local.ps1` receives an external private key path and the matching full public key.**

```powershell
.\pack-local.ps1 `
  -Version 0.1.0-preview.1 `
  -StrongNameKeyFile C:\secure\keys\Fmacias.TplQueue.official.snk `
  -StrongNamePublicKey <public-key>
```

This repository does not contain the official `.snk` key and does not reference a repository-local key path. Anyone building from source can choose their own signing strategy for their own distribution. Only packages built with the official private key carry the official TplQueue strong-name identity.

This is assembly strong-name signing only. NuGet package X.509 signing and obfuscation are not part of the current v1.0.0 release flow; the central policy is maintained in `..\WorkspaceTplQueue\docs\release-policy.md`.

## License

`TplQueue.Abstractions` is distributed under the MIT license.

## Switch between local and nuget.org sources

The [NuGet.config](./NuGet.config) file defines both the local feed and nuget.org. To switch which one is used for restores, either enable or disable the source, or edit the file directly.

Option A: enable or disable sources

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

1. Update the version in `src/Fmacias.TplQueue.Abstractions.csproj` or override it through the pack pipeline.
2. Pack the release build:

```powershell
dotnet pack .\Fmacias.TplQueue.Abstractions.sln -c Release -o ..\TplQueue.NugetLocal -p:SkipPackLocal=true
```

3. Push the package to NuGet.org:

```powershell
dotnet nuget push ..\TplQueue.NugetLocal\Fmacias.TplQueue.Abstractions.1.2.3.nupkg `
  --source https://api.nuget.org/v3/index.json `
  --api-key <YOUR_NUGET_API_KEY>
```

## Payload handler contract status

Current state:

- `IPayload.PayloadId` is the single stable persisted handler key for hydrated payload jobs
- `IPayloadHandlers` resolves public `IHandler` implementations only by that stable string key
- handler classes can be composed from the application layer or an IoC container through handler factories
- application-level grouping logic should call the direct `IApi.RegisterPayloadHandler(...)` overloads itself instead of relying on a plugin abstraction in this package layer

Deferred work:

- keep any future higher-level discovery or module-loading helper outside this package layer
- keep direct `IApi.RegisterPayloadHandler(...)` registration as the composition boundary for payload handlers

## Visual Studio session note

Avoid opening `WorkspaceTplQueue.sln` and any `TplQueue.*.sln` in separate Visual Studio sessions at the same time. The workspace swaps to project references, while standalone solutions stay package-based, and running both can lead to confusing dependency views or build output conflicts.
