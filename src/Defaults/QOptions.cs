using Fmacias.TplQueue.Contracts;
using System;

namespace Fmacias.TplQueue.Defaults
{
    /// <summary>
    /// Immutable queue options used by <see cref="IQFactory"/> to create configured dispatchers.
    /// </summary>
    /// <remarks>
    /// This default artifact is a value object. It is acceptable in
    /// <c>Fmacias.TplQueue.Defaults</c> because it carries explicit constructor values only,
    /// changes no global state, and does not retain mutable shared state.
    /// </remarks>
    public class QOptions : IQOptions
    {
        /// <inheritdoc />
        public int MaxParallelism { get; }

        /// <inheritdoc />
        public string RetryPolicy { get; }

        /// <inheritdoc />
        public Guid Id { get; }

        /// <summary>
        /// Initializes immutable queue options.
        /// </summary>
        /// <param name="id">The queue option identifier.</param>
        /// <param name="maxParallelism">The maximum number of jobs allowed to execute in parallel.</param>
        /// <param name="retryPolicy">The retry policy name associated with this queue configuration.</param>
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
