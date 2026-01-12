using System;

namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    public interface IExponentialBackofRetryPolicyOptions
    {
        int MaxRetries { get; }
        bool ReenqueueOnFailure { get; }
        TimeSpan InitialDelay { get; }
        bool ShouldRetry { get; }
    }
}
