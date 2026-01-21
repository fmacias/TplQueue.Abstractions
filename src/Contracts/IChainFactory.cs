using Microsoft.Extensions.Logging;
using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Factory that creates configured task dispatchers (parallel, serializable, strict FIFO).
    /// </summary>
    public interface IChainFactory
    {
        /// <summary>Create a parallel dispatcher from full options.</summary>
        IParallelChain CreateParallel(IChainOptions chainOptions, string name, ILogger logger);

        /// <summary>Create a parallel dispatcher from explicit parameters.</summary>
        IParallelChain CreateParallel(string name, Func<IRetryPolicy> retryPolicyFactory, int maxParallelism, ILogger logger, int pulseMs);

        /// <summary>Create a parallel dispatcher from named options.</summary>
        IParallelChain CreateParallel(string name, ILogger logger);

        /// <summary>Create a strict FIFO dispatcher from full options.</summary>
        IFifoChain CreateFifo(IChainOptions chainOptions, string name, ILogger logger);

        /// <summary>Create a strict FIFO dispatcher from explicit parameters.</summary>
        IFifoChain CreateFifo(string name, Func<IRetryPolicy> retryPolicyFactory, int pulseMs, ILogger logger);

        /// <summary>Create a strict FIFO dispatcher from named options.</summary>
        IFifoChain CreateFifo(string name, ILogger logger);

        /// <summary>Retrieve a named chain instance cast to the requested interface.</summary>
        T GetChain<T>(string name, ILoggerFactory loggerFactory) 
            where T : class, IJobsChain;
    }
}
