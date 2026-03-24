using Fmacias.TplQueue.Contracts;
using System;

namespace Fmacias.TplQueue.Defaults
{
    /// <summary>
    /// Options used by <see cref="IQFactory"/> to create configured dispatchers.
    /// Immutable-after-construction;
    /// </summary>
    public class QOptions : IQOptions
    {   public int MaxParallelism { get; }
        public string RetryPolicy { get; }
        public Guid Id { get; }

        public QOptions(Guid id, int maxParallelism, string retryPolicy)
        {
            if (id == null || id == Guid.Empty) throw new ArgumentNullException(nameof(id));
            if (maxParallelism < 1) throw new ArgumentOutOfRangeException(nameof(maxParallelism));
            if (string.IsNullOrWhiteSpace(retryPolicy)) throw new ArgumentException("RetryPolicy cannot be null/empty.", nameof(retryPolicy));
            Id = id;
            MaxParallelism = maxParallelism;
            RetryPolicy = retryPolicy;
        }
    }
}
