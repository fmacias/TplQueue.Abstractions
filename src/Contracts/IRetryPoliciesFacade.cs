using System.Collections.Generic;

namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    public interface IRetryPoliciesFacade
    {
        IRetryPolicyFactory GetRetryPolicyFactory(IReadOnlyDictionary<string, RetryPolicyOptions> options);
        IRetryPolicySerializable GetRetryPolicySerializer();
    }
}
