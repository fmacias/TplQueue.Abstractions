using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// A serializable snapshot of a retry policy configuration.
    /// Persist this for root payloads so they can be rehydrated identically.
    /// </summary>
    public interface IRetryPolicyOptions
    {
        int MaxRetries { get; }
        int BaseDelayMs { get; }
        double Factor { get; }
    }
}
