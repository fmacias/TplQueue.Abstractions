using Microsoft.Extensions.Logging;
using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Factory that creates configured task dispatchers (parallel, serializable, strict FIFO).
    /// </summary>
    public interface IQFactory
    {
        /// <summary>Create a parallel dispatcher from full options.</summary>
        IParallelQ CreateParallel(IChainOptions chainOptions, string name, ILogger logger);

        /// <summary>Create a parallel dispatcher from explicit parameters.</summary>
        IParallelQ CreateParallel(string name, Func<IRetryPolicy> retryPolicyFactory, int maxParallelism, ILogger logger, int pulseMs);

        /// <summary>Create a parallel dispatcher from named options.</summary>
        IParallelQ CreateParallel(string name, ILogger logger);

        /// <summary>Create a strict FIFO dispatcher from full options.</summary>
        IFifoQ CreateFifo(IChainOptions chainOptions, string name, ILogger logger);

        /// <summary>Create a strict FIFO dispatcher from explicit parameters.</summary>
        IFifoQ CreateFifo(string name, Func<IRetryPolicy> retryPolicyFactory, int pulseMs, ILogger logger);

        /// <summary>Create a strict FIFO dispatcher from named options.</summary>
        IFifoQ CreateFifo(string name, ILogger logger);

        /// <summary>Retrieve a named chain instance cast to the requested interface.</summary>
        T GetChain<T>(string name, ILoggerFactory loggerFactory) 
            where T : class, IJobQ;
    }
}
