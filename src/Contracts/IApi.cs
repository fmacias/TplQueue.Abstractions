using System;
using System.Collections.Generic;

namespace Fmacias.TplQueue.Contracts
{
    public interface IApi
    {
        IRetryPolicyGenericFactory RetryPolicyGenericFactory { get; }
        Lazy<IJobRootFactory> JobRootFactory { get; }
        Lazy<IJobFactory> JobFactory { get; }
        IDataJobFactory DataJobFactory(IPayloadHandlerResolver payloadHandlerResolver);
        Lazy<ICacheQFactory> CacheQFactory { get; }
        Lazy<ICoreQFactoryAdapter> CoreQFactories { get; }
        IReadOnlyDictionary<string, IRetryPolicyDescriptor> RetryPolicyOptions { get; }
        IReadOnlyDictionary<string, IQOptions> QueueOptions { get; }
        T Cache<T>(
            ICacheFactory<T> cacheFactory,
            IUniversalDataSerializer serializer,
            INodeTypeResolver typeResolver, 
            IPayloadHandlerResolver payloadHandlerResolver)
            where T : IDataJobCache;
        T RetryPolicy<T>(IRetryPolicyFactory<T> retryPolicyFactory, string name)
            where T : IRetryPolicy;
        ISystemTextJsonSerializerFactory SystemTexSerializerFactory();
        IObserverFactory ObserverFactory();

    }
}
