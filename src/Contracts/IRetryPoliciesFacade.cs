using Fmacias.TplQueue;
using System.Collections.Generic;

namespace Fmacias.TplQueue.Contracts
{
    public interface IRetryPoliciesFacade
    {
        IRetryPolicyFactory GetRetryPolicyFactory(IReadOnlyDictionary<string, RetryPolicyOptions> options);
        IRetryPolicySerializable GetRetryPolicySerializer();
    }
}
