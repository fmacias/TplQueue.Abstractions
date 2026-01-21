using System.Collections.Generic;

namespace Fmacias.TplQueue.Contracts
{
    public interface IApi: ICoreApi
    {
        IObserverFactory GetObserverFactory();
        ICacheFactory GetCacheFactory();
        IPayloadJobFactory GetPayloadJobFactory();
        ICacheableChainFactory GetSerializableDispatcherFactory();
        IRetryPolicyFactory GetRetryPolicyFactory(IReadOnlyDictionary<string, RetryPolicyOptions> options);
        ICoreApi GetCoreApi();
    }
}
