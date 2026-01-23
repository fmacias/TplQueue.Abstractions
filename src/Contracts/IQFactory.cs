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
        IParallelQ CreateParallel(IQOptions chainOptions, string name, ILogger logger);

        /// <summary>Create a parallel dispatcher from explicit parameters.</summary>
        IParallelQ CreateParallel(string name, int maxParallelism, ILogger logger, Func<IRetryPolicy>? retryPolicyFactory = null);

        /// <summary>Create a parallel dispatcher from named options.</summary>
        IParallelQ CreateParallel(string name, ILogger logger);

        /// <summary>Create a strict FIFO dispatcher from full options.</summary>
        IFifoQ CreateFifo(IQOptions chainOptions, string name, ILogger logger);

        /// <summary>Create a strict FIFO dispatcher from explicit parameters.</summary>
        IFifoQ CreateFifo(string name, ILogger logger, Func<IRetryPolicy>? retryPolicy = null);

        /// <summary>Create a strict FIFO dispatcher from named options.</summary>
        IFifoQ CreateFifo(string name, ILogger logger);

        /// <summary>Retrieve a named chain instance cast to the requested interface.</summary>
        T GetQ<T>(string name, ILoggerFactory loggerFactory) 
            where T : class, IJobQ;
    }
}
