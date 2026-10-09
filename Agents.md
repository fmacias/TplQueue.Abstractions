# AGENTS.md

## Repository context

You are working in the `TplQueue.Abstractions` git repository, part of the overall `fmacias` workspace.

Related repositories include:

- `TplQueue.Abstractions`
- `TplQueue.Core`
- `TplQueue.Adapter`
- `TplQueue.Usage`

Treat every repository as an independent git boundary even when code, packages, documentation, tests, or samples depend on another repository.

When this repository is checked out inside the overall `fmacias` workspace and an applicable parent `AGENTS.md` exists, apply those common instructions first.

This file adds repository-specific instructions for `TplQueue.Abstractions`.

The repository follows the standard workspace organization with production code under `src` and tests under `test`.

Production libraries intentionally target `netstandard2.0`.

This compatibility target allows the contracts to remain usable from older .NET Framework applications as well as modern .NET runtimes where supported.

When working inside an area containing a more-specific `AGENTS.md`, read that file in addition to this root file.

---

## Instruction and source-of-truth hierarchy

Apply instructions and evidence in this order:

1. explicit human task
2. applicable workspace-level `AGENTS.md`
3. this repository root `AGENTS.md`
4. nearest more-specific `AGENTS.md`
5. current source code
6. current tests
7. applicable migration/architecture documentation
8. installed Agent Skills as workflow guidance

Skills complement repository instructions.

They do not replace repository-local source of truth.

If an installed Skill describes an older baseline than the current repository, follow the repository's current source, tests, instructions, and applicable documentation.

Do not silently reconcile contradictions between repositories.

---

## Agent Skills

When available, use Skills from the `engineering` plugin for generic engineering procedure, including:

- `review-csharp`
- `review-concurrency`
- `review-public-api`
- `architecture-review`
- `refactor-code`
- `implement-feature`
- `testing-dotnet`
- `validate-dotnet-change`
- `align-cross-repository-documentation`
- `document-csharp-api`
- `summarize-staged-commit`

Do not duplicate those generic workflows in this file.

When available, use the `tplqueue-abstractions` plugin for Abstractions-specific workflows:

- `review-abstractions-architecture`
- `modify-abstractions-public-contracts`
- `modify-execution-channel-observation`

Additional Abstractions-specific Skills should only be created when a distinct reusable contract workflow or behavioral invariant justifies them.

Do not create one Skill per interface or folder.

---

## Repository role

`TplQueue.Abstractions` defines reusable contracts shared by the TplQueue ecosystem.

Keep this repository focused on public abstractions and contract definitions.

Avoid introducing concrete runtime implementation concerns into public contracts when those concerns belong to Core, Adapter, or consumer repositories.

Public contracts should express the behavior required from implementations without unnecessarily constraining implementation details.

Changes to this repository may have broad downstream impact and must be evaluated accordingly.

---

## Compatibility

Production code targets `netstandard2.0`.

Preserve this compatibility unless the human explicitly requests a framework-policy change.

Repository configuration may enable modern C# language features, but do not introduce public API or runtime dependencies that violate the production compatibility target.

Do not introduce new external dependencies unless explicitly requested.

Do not change namespaces unless strictly necessary.

Minimize public API changes.

---

## Domain terminology

Use the terminology already established by the current codebase.

The current core domain contracts include:

- `IJob`
- `IJobRoot`
- `IDataJob`
- `IDataJobRoot`
- `IParallelQ`
- `IFifoQ`
- `ICacheQ`

Use these names consistently in:

- analysis
- implementation
- refactoring
- tests
- comments
- XML documentation
- public documentation

Do not rename these concepts or replace them with alternative terminology unless the human explicitly requests it.

Older names such as `TaskRunner`, `TaskRunnerRoot`, and related historical abstractions are legacy terminology.

Preserve them where compatibility or existing source requires it, but prefer the current Job-based terminology in new work.

Do not introduce parallel vocabulary such as `job`, `task runner`, and `work item` for the same abstraction.

Do not perform broad terminology migrations unless explicitly requested.

---

## Architectural intent

The TplQueue contracts support infrastructure for:

- controlled asynchronous and concurrent execution
- strict FIFO execution where required
- parallel dispatch where allowed
- retry-policy-driven execution
- observable execution flow
- optional payload handling through `IDataJob` and `IDataJobRoot`
- optional cache-backed dispatch integration
- monitoring and front-end integration without coupling UI concerns into the abstraction layer

A dispatcher queue conceptually operates on `IJobRoot` elements and may provide FIFO or parallel execution behavior depending on the implementation.

The abstractions should allow legacy and modern applications to consume TplQueue functionality without requiring a particular UI, host, storage system, or concrete dispatcher implementation.

Preserve this architectural direction unless the explicit task deliberately changes it.

---

## Public contract changes

Treat modifications to public interfaces, public DTO/event contracts, public enums, records, structs, extension-facing contracts, or other externally consumed types as API changes.

Before changing a public contract:

1. identify the owning contract;
2. inspect current tests;
3. identify Core consumers;
4. identify Adapter consumers;
5. identify Usage consumers;
6. determine compatibility and migration impact.

Prefer compatible extensions where practical.

Do not expose concrete implementation details merely to simplify a consumer implementation.

When a deliberate breaking or coordinated API migration is required, update the affected source, tests, repository instructions, migration information, and downstream-impact notes coherently.

Use `modify-abstractions-public-contracts` when available.

---

## Current coordinated contract baseline

The current source line participates in coordinated API work involving contracts such as:

- `WaitAsync`
- `IPayload.HandlerKey`
- current `Then` extension ownership/location
- CacheQ creation APIs where they intersect with public contracts

Follow the coordinated API migration notes maintained with the public Adapter documentation:

`../TplQueue.Adapter/docs/en/operations/api-migration.md`

Do not assume that every item in a coordinated migration is owned by `TplQueue.Abstractions`.

Determine ownership from the actual source and project structure.

Runtime implementation semantics belonging to Core or Adapter must not be copied into Abstractions merely because they participate in the same migration.

When an Abstractions contract changes, identify the required Core, Adapter, and Usage consumer changes explicitly.

---

## Execution-channel observation

The optional `IJobExecutionEvent` contract adds nullable `ExecutionChannel` metadata without changing `IJobEvent`.

Current semantics are:

- `IJobExecutionEvent` is optional;
- `ExecutionChannel` is nullable;
- a non-null value identifies queue-local execution capacity;
- the value remains stable across retries while that capacity is held;
- terminal events capture the channel before execution capacity is released;
- pre-execution events remain unassigned;
- legacy events remain unassigned unless they expose the optional contract;
- execution-channel metadata is diagnostic information;
- an execution channel is not a thread ID;
- execution-channel metadata is not a scheduling-control mechanism.

Do not add execution-channel semantics to `IJobEvent` merely for convenience while the optional-interface model remains the current contract.

Do not introduce assumptions that execution channels are globally unique or directly correspond to operating-system threads.

Changes to this contract may affect Core event generation, Adapter Observer integration, and Usage monitoring/visualization.

Identify those impacts explicitly.

Use `modify-execution-channel-observation` when available.

---

## Related repositories

### TplQueue.Core

Core implements runtime behavior against Abstractions contracts.

When an Abstractions change requires Core implementation changes, identify the impact explicitly and respect Core as a separate git boundary.

Do not encode private Core implementation assumptions in public Abstractions contracts.

### TplQueue.Adapter

Adapter provides facade and integration packages built around Abstractions and Core-facing behavior.

Changes to Abstractions may affect Adapter compilation, public APIs, integration packages, configuration, and public documentation.

Public end-user documentation is currently published from Adapter's documentation trees.

If an Abstractions change alters documented public behavior, identify the corresponding Adapter documentation update.

### TplQueue.Usage

Usage is a separate consumer/integration repository containing samples and executable usage scenarios.

When an Abstractions change affects Usage:

- identify the consumer impact;
- do not place Usage-specific implementation in Abstractions;
- do not modify Usage during an Abstractions-only task unless explicitly requested;
- use the `tplqueue-usage` plugin for Usage-specific work when available.

---

## Tests

Keep tests aligned with public contract changes.

When changing an abstraction, cover the contract behavior needed to protect compatibility and intended semantics.

Use the generic `testing-dotnet` workflow when available.

Repository-specific contract tests should focus on behavior and compatibility relevant to the changed abstraction.

Do not duplicate generic test methodology in this file.

---

## Documentation and cross-repository alignment

When a public contract or terminology change affects multiple repositories:

- inspect the relevant root `AGENTS.md` and `README.md` files;
- inspect more-specific documentation instructions where present;
- identify contradictions before changing documentation;
- do not silently normalize inconsistent repository descriptions;
- keep migration guidance and public documentation aligned with the actual contracts.

Use `align-cross-repository-documentation` when available.

Public documentation publishing remains owned by the Adapter documentation trees unless explicitly changed.

---

## Validation

For production changes, validate the affected scope as applicable:

- build affected projects;
- run relevant unit tests;
- pack locally using the repository packaging mechanism when applicable;
- run integration tests that depend on packaged outputs when applicable;
- report any validation step that could not be executed.

Use `validate-dotnet-change` when available for the generic validation workflow.

---

## Change-scope guidance

Prefer the smallest coherent contract change that satisfies the requested behavior.

Keep work inside `TplQueue.Abstractions` unless the explicit task includes cross-repository changes.

If another repository must change:

- explain why;
- identify the affected contract;
- identify the required downstream work;
- respect that repository's own AGENTS.md and plugin guidance.

Do not silently expand an Abstractions-only task into Core, Adapter, or Usage.