using Fmaciasruano.TplQueue.Abstractions.Contracts;
using System;

namespace Fmaciasruano.TplQueue.Abstractions
{
    /// <summary>
    /// <![CDATA[
    /// Immutable, serialization-friendly snapshot of a retry policy configuration.
    ///
    /// Typical usage:
    ///   - At configuration time, create descriptors via the static helpers
    ///     (None, Linear, Exponential, Personalized).
    ///   - Persist the descriptor together with a job or payload.
    ///   - At rehydration time, pass the descriptor to IRetryPolicyFactory.Create(descriptor).
    ///
    /// The <see cref="RetryPolicyType"/> can be an interface for built-in policies
    /// (e.g. ILinearBackoffRetryPolicy) or a concrete type for plugin policies.
    /// ]]>
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1815:Override equals and operator equals on value types", Justification = "<Pending>")]
    public readonly struct RetryPolicyDescriptor : IRetryPolicyDescriptor
    {
        /// <inheritdoc />
        public string Kind { get; }

        /// <inheritdoc />
        public int? MaxRetries { get; }

        /// <inheritdoc />
        public int? BaseDelayMs { get; }

        /// <inheritdoc />
        public double? Factor { get; }

        /// <inheritdoc />
        public bool? ShouldRetry { get; }

        /// <inheritdoc />
        public Type? RetryPolicyType { get; }

        private RetryPolicyDescriptor(
            string kind,
            Type? retryPolicyType,
            int? maxRetries,
            int? baseDelayMs,
            double? factor,
            bool? shouldRetry)
        {
            Kind = kind ?? "none";
            RetryPolicyType = retryPolicyType;
            MaxRetries = maxRetries;
            BaseDelayMs = baseDelayMs;
            Factor = factor;
            ShouldRetry = shouldRetry;
        }

        /// <summary>
        /// Create an empty descriptor; useful as a neutral default before configuration.
        /// </summary>
        public static IRetryPolicyDescriptor Create()
            => new RetryPolicyDescriptor(kind: "none", retryPolicyType: null, maxRetries: null, baseDelayMs: null, factor: null, shouldRetry: null);

        /// <summary>
        /// Create a descriptor for a custom / plugin policy.
        /// </summary>
        /// <param name="kind">Logical kind name (e.g. "my-custom-policy").</param>
        /// <param name="retrypolicyType">Concrete <see cref="Type"/> implementing <see cref="IRetryPolicy"/>.</param>
        /// <param name="maxRetries">Optional maximum retry count.</param>
        /// <param name="baseDelayMs">Optional base delay in milliseconds.</param>
        /// <param name="factor">Optional exponential factor.</param>
        /// <param name="shouldRetry">Whether the policy should actually retry.</param>
        /// <returns>Descriptor instance.</returns>
        public static IRetryPolicyDescriptor Personalized(
            string kind,
            Type retrypolicyType,
            int? maxRetries,
            int? baseDelayMs,
            double? factor,
            bool? shouldRetry)
        {
            if (retrypolicyType is null)
                throw new ArgumentNullException(nameof(retrypolicyType));

            return new RetryPolicyDescriptor(kind, retrypolicyType, maxRetries, baseDelayMs, factor, shouldRetry);
        }

        /// <summary>
        /// Descriptor for <see cref="NoRetryPolicy"/>.
        /// </summary>
        public static IRetryPolicyDescriptor None
            => new RetryPolicyDescriptor("none", typeof(NoRetryPolicy), maxRetries: 0, baseDelayMs: 0, factor: null, shouldRetry: false);

        /// <summary>
        /// Descriptor for a linear backoff retry policy.
        /// </summary>
        public static IRetryPolicyDescriptor Linear(int maxRetries, int baseDelayMs, bool shouldRetry = true)
            => new RetryPolicyDescriptor("linear", typeof(ILinearBackoffRetryPolicy), maxRetries, baseDelayMs, factor: null, shouldRetry: shouldRetry);

        /// <summary>
        /// Descriptor for an exponential backoff retry policy.
        /// </summary>
        public static IRetryPolicyDescriptor Exponential(int maxRetries, int baseDelayMs, double factor, bool shouldRetry = true)
            => new RetryPolicyDescriptor("exponential", typeof(IExponentialFactorRetryPolicy), maxRetries, baseDelayMs, factor, shouldRetry);
    }
}
