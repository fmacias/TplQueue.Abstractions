using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// <![CDATA[
    /// Factory responsible for creating concrete retry policy instances from:
    ///  - A logical name (resolved to RetryPolicyOptions),
    ///  - A RetryPolicyOptions value object,
    ///  - A serialized IRetryPolicyDescriptor (rehydration scenario),
    ///  - Or strongly-typed helper methods for the built-in policies.
    ///
    /// This interface lives in the Abstractions layer so that higher-level components
    /// can request retry policies without depending on concrete implementations.
    /// ]]>
    /// </summary>
    public interface IRetryPolicyFactory
    {
        /// <summary>
        /// Create a retry policy by name from a configured options map.
        /// </summary>
        /// <param name="name">Logical policy name; must exist in the configured options dictionary.</param>
        /// <returns>An <see cref="IRetryPolicy"/> instance.</returns>
        IRetryPolicy Create(string name);

        /// <summary>
        /// Create a retry policy from options.
        /// </summary>
        /// <param name="options">Options describing the retry strategy.</param>
        /// <returns>An <see cref="IRetryPolicy"/> instance.</returns>
        IRetryPolicy Create(RetryPolicyOptions options);

        /// <summary>
        /// Create a retry policy from a previously persisted descriptor.
        /// Intended for rehydration scenarios (e.g. from cache, database, message).
        /// </summary>
        /// <param name="descriptor">Descriptor describing the retry strategy.</param>
        /// <returns>An <see cref="IRetryPolicy"/> instance.</returns>
        IRetryPolicy Create(IRetryPolicyDescriptor descriptor);

        /// <summary>
        /// Create a policy that never retries (single attempt only).
        /// </summary>
        /// <returns>An <see cref="INoRetryPolicy"/> instance.</returns>
        INoRetryPolicy CreateNoRetryPolicy();

        /// <summary>
        /// Create an explicit exponential backoff policy.
        /// </summary>
        /// <param name="maxRetries">Maximum number of retries before the last exception is rethrown.</param>
        /// <param name="factor">Exponential factor (&gt; 0).</param>
        /// <param name="shouldRetry">If false, this is equivalent to <see cref="CreateNoRetryPolicy"/>.</param>
        /// <param name="baseDelayMilliseconds">Base delay in milliseconds for the first retry.</param>
        /// <returns>An <see cref="IExponentialFactorRetryPolicy"/> instance.</returns>
        IExponentialFactorRetryPolicy CreateExponentialBackoff(
            int maxRetries,
            double factor,
            bool shouldRetry,
            int baseDelayMilliseconds);

        /// <summary>
        /// Create an explicit linear backoff policy.
        /// </summary>
        /// <param name="maxRetries">Maximum number of retries before the last exception is rethrown.</param>
        /// <param name="baseDelayMilliseconds">Delay in milliseconds between retries.</param>
        /// 
        /// <returns>An <see cref="ILinearBackoffRetryPolicy"/> instance.</returns>
        ILinearBackoffRetryPolicy CreateLinearBackoff(
            int maxRetries,
            int baseDelayMilliseconds);

        /// <summary>
        /// Convenience helper to create a policy by name and cast it to a specific interface.
        /// </summary>
        /// <typeparam name="T">Expected policy interface.</typeparam>
        /// <param name="name">Logical policy name.</param>
        /// <returns>Policy instance cast to <typeparamref name="T"/>.</returns>
        T GetRetryPolicy<T>(string name) where T : class, IRetryPolicy;
    }
}
