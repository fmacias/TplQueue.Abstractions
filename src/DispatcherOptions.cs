using Fmacias.TplQueue.Contracts;

namespace Fmacias.TplQueue
{
    /// <summary>
    /// Options used by <see cref="ITaskDispatcherFactory"/> to create configured dispatchers.
    /// Immutable-after-construction; validates invariants based on <see cref="Kind"/>.
    /// </summary>
    public class DispatcherOptions : IDispatcherOptions
    {
        public DispatcherKind Kind { get; private set; }
        public int MaxParallelism { get; private set; }
        public int PulseMs { get; private set; }
        public string RetryPolicy { get; private set; }
 
        public DispatcherOptions(
            DispatcherKind kind,
            int maxParallelism,
            int pulseMs,
            string retryPolicy)
        {
            if (maxParallelism < 1) throw new System.ArgumentOutOfRangeException(nameof(maxParallelism));
            if (pulseMs <= 0) throw new System.ArgumentOutOfRangeException(nameof(pulseMs));
            if (string.IsNullOrWhiteSpace(retryPolicy)) throw new System.ArgumentException("RetryPolicy cannot be null/empty.", nameof(retryPolicy));
            Kind = kind;
            MaxParallelism = maxParallelism;
            PulseMs = pulseMs;
            RetryPolicy = retryPolicy;
        }
    }
}
