using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Options contract for exponential-backoff retry policies.
    /// </summary>
    /// <remarks>
    /// The public type name is retained for compatibility with the preview line and is not being
    /// renamed as part of the first stable API freeze.
    /// </remarks>
    public interface IExponentialBackofRetryPolicyOptions
    {
        int MaxRetries { get; }
        bool ReenqueueOnFailure { get; }
        TimeSpan InitialDelay { get; }
        bool ShouldRetry { get; }
    }
}
