using Fmacias.TplQueue.Contracts;

namespace Fmacias.TplQueue
{
    /// <summary>
    /// Options used by <see cref="ICoreQFactory"/> to create configured dispatchers.
    /// Immutable-after-construction;
    /// </summary>
    public class QOptions : IQOptions
    {   public int MaxParallelism { get; private set; }
        public string RetryPolicy { get; private set; }
 
        public QOptions(int maxParallelism, string retryPolicy)
        {
            if (maxParallelism < 1) throw new System.ArgumentOutOfRangeException(nameof(maxParallelism));
            if (string.IsNullOrWhiteSpace(retryPolicy)) throw new System.ArgumentException("RetryPolicy cannot be null/empty.", nameof(retryPolicy));

            MaxParallelism = maxParallelism;
            RetryPolicy = retryPolicy;
        }
    }
}
