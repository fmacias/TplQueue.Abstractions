using System.Collections.Generic;

namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    /// <summary>
    /// High-level API (facade) to construct dispatchers, retry policies and task runners
    /// using the registered factories. This type does not execute work; it only creates
    /// configured instances for consumption.
    /// </summary>
    public interface ICoreFacade
    {
        IPayloadRunnerFactory GetPayloadRunnerFactory();
        IPayloadRunnerFactory GetPayloadRunnerFactory(IUniversalPayloadSerializer serializer);
        IPayloadRunnerFactory GetPayloadRunnerFactory(IRetryPolicySerializer retryPolicySerializer);
        IPayloadRunnerFactory GetPayloadRunnerFactory(IUniversalPayloadSerializer serializer, IRetryPolicySerializer retryPolicySerializer);
        ITaskDispatcherFactory GetTaskDispatcherFactory(IRetryPolicyFactory retries, IReadOnlyDictionary<string, IDispatcherOptions>? options = null);
        ITaskRunnerFactory GetTaskRunnerFactory();
        ITaskRunnerRootFactory GetTaskRunnerRootFactory();
    }
}
