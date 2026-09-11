using System;

namespace Fmacias.TplQueue.Contracts
{
    public interface IQOptions
    {
        Guid Id { get; }
        int MaxParallelism { get; }
        /// <summary>
        /// Gets the optional retry-policy name. Null, empty, or whitespace selects NoRetry.
        /// </summary>
        string? RetryPolicy { get; }
    }
}
