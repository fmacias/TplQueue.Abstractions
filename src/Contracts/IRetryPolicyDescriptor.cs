using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// A serializable snapshot of a retry policy configuration.
    /// Persist this for root payloads so they can be rehydrated identically.
    /// </summary>
    public interface IRetryPolicyDescriptor
    {
        int MaxRetries { get; }
        int BaseDelayMs { get; }
        double Factor { get; }
        Type? RetryPolicyType { get; }
        IRetryPolicyDescriptor SetRetryPolicyType(Type retryPolicyType);
    }
}
