using Microsoft.Extensions.Logging;
using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Factory that creates configured task dispatchers (parallel, serializable, strict FIFO).
    /// </summary>
    public interface ITaskDispatcherFactory
    {
        /// <summary>Create a parallel dispatcher from full options.</summary>
        IParallelTaskDispatcher CreateParallel(IDispatcherOptions dispatcherOptions, string name, ILogger logger);

        /// <summary>Create a parallel dispatcher from explicit parameters.</summary>
        IParallelTaskDispatcher CreateParallel(string name, Func<IRetryPolicy> retryPolicyFactory, int maxParallelism, ILogger logger, int pulseMs);

        /// <summary>Create a parallel dispatcher from named options.</summary>
        IParallelTaskDispatcher CreateParallel(string name, ILogger logger);

        /// <summary>Create a strict FIFO dispatcher from full options.</summary>
        IStrictFifoTaskDispatcher CreateStrictFifo(IDispatcherOptions dispatcherOptions, string name, ILogger logger);

        /// <summary>Create a strict FIFO dispatcher from explicit parameters.</summary>
        IStrictFifoTaskDispatcher CreateStrictFifo(string name, Func<IRetryPolicy> retryPolicyFactory, int pulseMs, ILogger logger);

        /// <summary>Create a strict FIFO dispatcher from named options.</summary>
        IStrictFifoTaskDispatcher CreateStrictFifo(string name, ILogger logger);

        /// <summary>Retrieve a named dispatcher instance cast to the requested interface.</summary>
        T GetDispatcher<T>(string name, ILoggerFactory loggerFactory) 
            where T : class, ITaskDispatcher;
    }
}
