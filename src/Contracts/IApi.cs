using Fmaciasruano.TplQueue.Abstractions;
using System.Collections.Generic;

namespace Fmaciasruano.TplQueue.Abstractions.Contracts
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
