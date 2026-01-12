using System;
using System.Collections.Generic;
using System.Text;

namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    public interface IApiFacade: ICoreFacade
    {
        ICacheFactory GetCacheFactory();
        IObserverFactory GetObserverFactory();
        IRetryPolicyFactory GetRetryPolicyFactory();
        IRetryPolicyFactory GetRetryPolicyFactory(IReadOnlyDictionary<string, RetryPolicyOptions> retryOptions);
    }
}
