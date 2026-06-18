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
        /// <summary>
        /// Creates a cache using the facade-owned default runtime type resolver.
        /// </summary>
        T Cache<T>(ICacheFactory<T> cacheFactory, IUniversalDataSerializer serializer)
            where T : IDataJobCache;
        /// <summary>
        /// Creates a cache using an explicit payload type resolver.
        /// </summary>
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
        T RetryPolicy<T>(IRetryPolicyFactory<T> retryPolicyFactory) 
            where T : IRetryPolicy;
        T RetryPolicy<T>(IRetryPolicyFactory<T> retryPolicyFactory, string name)
            where T : IRetryPolicy;
        T RetryPolicy<T>(IRetryPolicyFactory<T> retryPolicyFactory, IRetryPolicyOptions retryPolicyOptions)
            where T : IRetryPolicy;
        IExponentialBackoff RetryPolicy(IExponentialBackoffFactory exponentialBackoffFactory, int maxRetries, int delayMs, double factor);
        ILinearBackoff RetryPolicy(ILinearBackoffFactory linearBackofFactory, int maxRetries, int delayMs);
        /// <summary>
        /// Creates the System.Text.Json serializer factory exposed by the adapter facade.
        /// </summary>
        /// <returns>A System.Text.Json serializer factory.</returns>
        ISystemTextJsonSerializerFactory SystemTextSerializerFactory();
        /// <summary>
        /// Creates the XML serializer factory exposed by the adapter facade.
        /// </summary>
        /// <returns>An XML serializer factory.</returns>
        IXmlSerializerFactory XmlSerializerFactory();
        IObserverFactory ObserverFactory();
    }
}
 
