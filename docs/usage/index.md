# Usage

`TplQueue.Abstractions` is the contract-only package in the TplQueue line.

## Main topics

- job graph contracts: `IJob`, `IJobRoot`, `IDataJob`, `IDataJobRoot`
- queue contracts: `IQ`, `IParallelQ`, `IFifoQ`, `ICacheQ`
- retry-policy contracts and related option models
- observer contracts and queue event shapes
- payload, serializer, and cache-hydration contracts

## How it is normally consumed

- `TplQueue.Core` uses these contracts to implement the execution kernel
- `TplQueue.Adapter` uses them to provide concrete integrations and factory facades
- application code can reference this package alone when only the public surface is needed

## Public package-consumption examples

`TplQueue.Abstractions` does not own runnable code by itself, so the canonical consumer-side examples live in [TplQueue.Usage](https://github.com/fmacias/TplQueue.Usage):

- [PackageConsumptionSmokeConsole](https://github.com/fmacias/TplQueue.Usage/tree/main/samples/PackageConsumptionSmokeConsole)
  Key focus: the smallest package-consumption surface for `IJob`, `IJobRoot`, queues, observers, retry policies, and payload-cache hydration.
- [QueueObserverConsole](https://github.com/fmacias/TplQueue.Usage/tree/main/samples/QueueObserverConsole)
  Key focus: a rooted `Extract -> Transform -> Load` pipeline plus a standalone helper task in the same queue.
- [QueueObserverSignalRDashboard](https://github.com/fmacias/TplQueue.Usage/tree/main/samples/QueueObserverSignalRDashboard)
  Key focus: consumer-side DTO projection, long-lived queues, and browser transport for queue events.

## Deeper detail

The previous long-form repository guide is preserved in [../reference.md](../reference.md).
