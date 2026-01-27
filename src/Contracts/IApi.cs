using System.Collections.Generic;

namespace Fmacias.TplQueue.Contracts
{
    public interface IApi: ICoreApi
    {
        IObserverFactory GetObserverFactory();
        ICacheFactory GetCacheFactory();
        IPayloadJobFactory GetPayloadJobFactory(IReadOnlyDictionary<string, RetryPolicyOptions>? options = null);
        ICacheableQFactory GetCacheableQFactory();
        IRetryPolicyFactory GetRetryPolicyFactory(IReadOnlyDictionary<string, RetryPolicyOptions> options);
        ICoreApi GetCoreApi();
        IQFactoryAdapter GetQFactory(IReadOnlyDictionary<string, IQOptions> options, IReadOnlyDictionary<string, RetryPolicyOptions>? retryPolicyOptions = null);
        ISystemTextJsonSerializerFactory GetSystemTextJsonSerializerFactory();
    }
}
