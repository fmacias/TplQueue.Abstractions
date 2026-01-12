using Fmaciasruano.TplQueue.Abstractions.Contracts;
using Fmaciasruano.TplQueue.RetryPolicies;
using System;

namespace Fmaciasruano.TplQueue.Abstractions
{
    public sealed class RetryPolicySerializer : IRetryPolicySerializer
    {
        private const string NONE = "NONE";
        private const string LINEAR = "LINEAR";
        private const string EXPONENTIAL = "EXPONENTIAL";
        private RetryPolicySerializer() { }
        public static RetryPolicySerializer Create()
        {
            return new RetryPolicySerializer();
        }
        public IRetryPolicyDescriptor ToDescriptor(Func<IRetryPolicy> factory)
        {
            if (factory is null) throw new ArgumentNullException(nameof(factory));
            var policy = factory();

            if (policy is INoRetryPolicy) return RetryPolicyDescriptor.None;

            if (policy is ILinearBackoffRetryPolicy linear)
            {
                var delayMs = (int)Math.Round((linear.Delay ?? TimeSpan.Zero).TotalMilliseconds);
                return RetryPolicyDescriptor.Linear(linear.MaxRetries, delayMs);
            }

            if (policy is IExponentialFactorRetryPolicy exp)
            {
                var delayMs = (int)Math.Round((exp.Delay ?? TimeSpan.Zero).TotalMilliseconds);
                return RetryPolicyDescriptor.Exponential(exp.MaxRetries, delayMs, exp.Factor);
            }

            return RetryPolicyDescriptor.None;
        }

        public Func<IRetryPolicy> FromDescriptor(IRetryPolicyDescriptor descriptor)
        {
            if (descriptor is null) throw new ArgumentNullException(nameof(descriptor));

            if (IsRetryDisabled(descriptor))
            {
                return () => NoRetryPolicy.Create();
            }

            return (descriptor.Kind ?? "none").ToUpperInvariant() switch
            {
                NONE => () => NoRetryPolicy.Create(),
                LINEAR => BuildLinearFactory(descriptor),
                EXPONENTIAL => BuildExponentialFactory(descriptor),
                _ => () => NoRetryPolicy.Create(),
            };
        }

        private static Func<IRetryPolicy> BuildLinearFactory(IRetryPolicyDescriptor descriptor)
        {
            var max = descriptor.MaxRetries ?? throw new ArgumentException("MaxRetries is required for linear retry policies.", nameof(descriptor));
            var ms = descriptor.BaseDelayMs ?? throw new ArgumentException("BaseDelayMs is required for linear retry policies.", nameof(descriptor));

            if (max <= 0) throw new ArgumentOutOfRangeException(nameof(descriptor.MaxRetries));
            if (ms <= 0) throw new ArgumentOutOfRangeException(nameof(descriptor.BaseDelayMs));

            return () => LinearBackoffRetryPolicy.Create(max, ms);
        }

        private static Func<IRetryPolicy> BuildExponentialFactory(IRetryPolicyDescriptor descriptor)
        {
            var max = descriptor.MaxRetries ?? throw new ArgumentException("MaxRetries is required for exponential retry policies.", nameof(descriptor));
            var ms = descriptor.BaseDelayMs ?? throw new ArgumentException("BaseDelayMs is required for exponential retry policies.", nameof(descriptor));
            var factor = descriptor.Factor ?? ExponentialBackoffRetryPolicy.DefaultFactor;

            if (max < 0) throw new ArgumentOutOfRangeException(nameof(descriptor.MaxRetries));
            if (ms <= 0) throw new ArgumentOutOfRangeException(nameof(descriptor.BaseDelayMs));
            if (factor <= 0d) throw new ArgumentOutOfRangeException(nameof(descriptor.Factor));

            return () => ExponentialBackoffRetryPolicy.Create(max, factor, ms);
        }

        private static bool IsRetryDisabled(IRetryPolicyDescriptor descriptor)
            => descriptor.ShouldRetry.HasValue && descriptor.ShouldRetry.Value == false;
    }
}
