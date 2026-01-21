using System;

namespace Fmacias.TplQueue.Contracts
{
    public interface IExponentialBackofRetryPolicyOptions
    {
        int MaxRetries { get; }
        bool ReenqueueOnFailure { get; }
        TimeSpan InitialDelay { get; }
        bool ShouldRetry { get; }
    }
}
