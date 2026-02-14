using System.Collections.Generic;

namespace Fmacias.TplQueue.Contracts
{
    public interface IApi: ICoreApi
    {
        IObserverFactory ObserverFactory();
        ICacheFactory CacheFactory();
        IPayloadJobFactory PayloadJobFactory(IReadOnlyDictionary<string, RetryPolicyOptions>? options = null);
        IPayloadJobFactory PayloadJobFactory(IJobHandlerResolver2 jobHandlerResolver, IReadOnlyDictionary<string, RetryPolicyOptions>? options = null);
        ICacheableQFactory CacheableQFactory();
        IRetryPolicyFactory RetryPolicyFactory(IReadOnlyDictionary<string, RetryPolicyOptions> options);
        ICoreApi GetCoreApi();
        IQFactoryAdapter QFactory(IReadOnlyDictionary<string, IQOptions> options, IReadOnlyDictionary<string, RetryPolicyOptions>? retryPolicyOptions = null);
        ISystemTextJsonSerializerFactory SystemTexSerializerFactory();
    }
}
