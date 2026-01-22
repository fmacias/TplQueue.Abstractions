using System.Collections.Generic;

namespace Fmacias.TplQueue.Contracts
{
    public interface IApi: ICoreApi
    {
        IObserverFactory GetObserverFactory();
        ICacheFactory GetCacheFactory();
        IPayloadJobFactory GetPayloadJobFactory();
        ICacheableQFactory GetSerializableDispatcherFactory();
        IRetryPolicyFactory GetRetryPolicyFactory(IReadOnlyDictionary<string, RetryPolicyOptions> options);
        ICoreApi GetCoreApi();
    }
}
