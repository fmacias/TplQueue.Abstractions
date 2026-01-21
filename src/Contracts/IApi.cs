using System.Collections.Generic;

namespace Fmacias.TplQueue.Contracts
{
    public interface IApi: ICoreApi
    {
        IObserverFactory GetObserverFactory();
        ICacheFactory GetCacheFactory();
        IPayloadRunnerFactory GetPayloadRunnerFactory();
        ISerializableDispatcherFactory GetSerializableDispatcherFactory();
        IRetryPolicyFactory GetRetryPolicyFactory(IReadOnlyDictionary<string, RetryPolicyOptions> options);
        ICoreApi GetCoreApi();
    }
}
