using System.Collections.Generic;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// High-level API (facade) to construct dispatchers, retry policies and task runners
    /// using the registered factories. This type does not execute work; it only creates
    /// configured instances for consumption.
    /// </summary>
    public interface ICoreApi
    {
        IChainFactory GetTaskDispatcherFactory(IReadOnlyDictionary<string, IChainOptions> options, IRetryPolicyFactory retries);
        IJobFactory GetJobFactory();
        IJobRootFactory GetJobRootFactory();
    }
}
