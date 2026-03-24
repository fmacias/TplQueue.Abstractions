using Microsoft.Extensions.Logging;
using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Factory that creates configured task dispatchers (parallel, serializable, strict FIFO).
    /// </summary>
    public interface IQFactory
    {
        /// <summary>Create a parallel dispatcher from explicit parameters.</summary>
        IParallelQ Parallel(Guid id, string name, int maxParallelism, ILogger logger, Func<IRetryPolicy>? retryPolicyFactory = null);

        /// <summary>Create a strict FIFO dispatcher from explicit parameters.</summary>
        IFifoQ Fifo(Guid id, string name, ILogger logger, Func<IRetryPolicy>? retryPolicy = null);
        ICacheQ CacheQ(ILogger<ICacheQ> logger, IDataJobCache payloadLeaseCache, IParallelQ queue);
    }
}
