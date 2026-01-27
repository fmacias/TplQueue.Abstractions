using Microsoft.Extensions.Logging;
using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Factory that creates configured task dispatchers (parallel, serializable, strict FIFO).
    /// </summary>
    public interface IQFactoryCore
    {
        /// <summary>Create a parallel dispatcher from explicit parameters.</summary>
        IParallelQ CreateParallel(string name, int maxParallelism, ILogger logger, Func<IRetryPolicy>? retryPolicyFactory = null);

        /// <summary>Create a strict FIFO dispatcher from explicit parameters.</summary>
        IFifoQ CreateFifo(string name, ILogger logger, Func<IRetryPolicy>? retryPolicy = null);
    }
}
