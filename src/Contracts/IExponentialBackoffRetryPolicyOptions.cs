using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Options contract for exponential-backoff retry policies.
    /// </summary>
    public interface IExponentialBackoffRetryPolicyOptions
    {
        int MaxRetries { get; }
        bool ReenqueueOnFailure { get; }
        TimeSpan InitialDelay { get; }
        bool ShouldRetry { get; }
    }
}
