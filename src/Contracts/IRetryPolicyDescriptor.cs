using System;

namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    /// <summary>
    /// A serializable snapshot of a retry policy configuration.
    /// Persist this for root payloads so they can be rehydrated identically.
    /// </summary>
    public interface IRetryPolicyDescriptor
    {
        string Kind { get; }
        int? MaxRetries { get; }
        int? BaseDelayMs { get; }
        double? Factor { get; }
        bool? ShouldRetry { get; }
        Type? RetryPolicyType { get; }
    }
}
