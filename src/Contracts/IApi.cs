using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Fmacias.TplQueue.Contracts
{
    public interface IApi
    {
        IRetryPolicyAbstractFactory RetryPolicyAbstractFactory { get; }
        IJobFactory JobFactory { get; }
        IDataJobFactory DataJobFactory { get; }
        IQFactoryAdapter QFactory { get; }
        IReadOnlyDictionary<string, IRetryPolicyOptions> RetryPolicyOptions { get; }
        IReadOnlyDictionary<string, IQOptions> QueueOptions { get; }
        T Cache<T>(ICacheFactory<T> cacheFactory, IUniversalDataSerializer serializer, ITypeResolver typeResolver)
            where T : IDataJobCache;
        /// <summary>
        /// Registers a payload handler instance by its stable payload handler key.
        /// </summary>
        IApi RegisterPayloadHandler(string payloadHandlerKey, IHandler handler);
        /// <summary>
        /// Registers a payload handler factory by its stable payload handler key.
        /// </summary>
        IApi RegisterPayloadHandler(string payloadHandlerKey, Func<IHandler> handlerFactory);
        /// <summary>
        /// Registers an untyped payload handler delegate by its stable payload handler key.
        /// </summary>
        IApi RegisterPayloadHandler(string payloadHandlerKey, Func<IPayload, CancellationToken, Task> handler);
        /// <summary>
        /// Registers a typed payload handler delegate by its stable payload handler key.
        /// </summary>
        IApi RegisterPayloadHandler<TPayload>(string payloadHandlerKey, Func<TPayload, CancellationToken, Task> handler)
            where TPayload : IPayload;
        /// <summary>
        /// Applies payload handler registrations from a plugin module.
        /// </summary>
        IApi RegisterPayloadHandlerPlugin(IPayloadHandlerPlugin plugin);
        T RetryPolicy<T>(IRetryPolicyFactory<T> retryPolicyFactory) 
            where T : IRetryPolicy;
        T RetryPolicy<T>(IRetryPolicyFactory<T> retryPolicyFactory, string name)
            where T : IRetryPolicy;
        T RetryPolicy<T>(IRetryPolicyFactory<T> retryPolicyFactory, IRetryPolicyOptions retryPolicyOptions)
            where T : IRetryPolicy;
        IExponentialBackoff RetryPolicy(IExponentialBackofFactory exponentialBackofFactory, int maxRetries, int delayMs, double factor);
        ILinearBackoff RetryPolicy(ILinearBackoffFactory linearBackofFactory, int maxRetries, int delayMs);
        ISystemTextJsonSerializerFactory SystemTexSerializerFactory();
        IObserverFactory ObserverFactory();
    }
}
 
