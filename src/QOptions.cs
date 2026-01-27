using Fmacias.TplQueue.Contracts;

namespace Fmacias.TplQueue
{
    /// <summary>
    /// Options used by <see cref="IQFactoryCore"/> to create configured dispatchers.
    /// Immutable-after-construction; validates invariants based on <see cref="Kind"/>.
    /// </summary>
    public class QOptions : IQOptions
    {
        public QKind Kind { get; private set; }
        public int MaxParallelism { get; private set; }
        public string RetryPolicy { get; private set; }
 
        public QOptions(
            QKind kind,
            int maxParallelism,
            string retryPolicy)
        {
            if (maxParallelism < 1) throw new System.ArgumentOutOfRangeException(nameof(maxParallelism));
            if (string.IsNullOrWhiteSpace(retryPolicy)) throw new System.ArgumentException("RetryPolicy cannot be null/empty.", nameof(retryPolicy));
            Kind = kind;
            MaxParallelism = maxParallelism;
            RetryPolicy = retryPolicy;
        }
    }
}
