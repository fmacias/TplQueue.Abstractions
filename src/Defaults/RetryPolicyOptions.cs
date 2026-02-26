using Fmacias.TplQueue.Contracts;
using System;

namespace Fmacias.TplQueue.Defaults
{
    /// <summary>
    /// Value object describing how to build a retry policy.
    /// <para>If <see cref="Factor"/> is <c>null</c> → Linear backoff.</para>
    /// <para>If <see cref="Factor"/> &gt; 0 → Exponential backoff.</para>
    /// </summary>
    public sealed class RetryPolicyOptions: IRetryPolicyDescriptor
    {
        public int BaseDelayMs { get; }
        public int MaxRetries { get; }
        public double Factor { get; }
        public Type? RetryPolicyType { get; private set; }

        private RetryPolicyOptions(int baseDelayMs, int maxRetries, double factor = 0d)
        {
            if (baseDelayMs < 0) throw new ArgumentOutOfRangeException(nameof(baseDelayMs));
            if (maxRetries < 0) throw new ArgumentOutOfRangeException(nameof(maxRetries));
            if (factor < 0d) throw new ArgumentOutOfRangeException(nameof(factor));
   
            BaseDelayMs = baseDelayMs;
            MaxRetries = maxRetries;
            Factor = factor;
        }
        public static RetryPolicyOptions Create(int baseDelayMs, int maxRetries, double factor= 0D)
        {
            return new RetryPolicyOptions(baseDelayMs, maxRetries, factor);
        }
        public IRetryPolicyDescriptor SetRetryPolicyType(Type retryPolicyType)
        {
            if (retryPolicyType == null) 
                throw new ArgumentNullException(nameof(retryPolicyType));
            
            if (typeof(IRetryPolicy).IsAssignableFrom(retryPolicyType) == false)
            {
                throw new InvalidOperationException(
                    $"Failed to create retry policy instance of type '{retryPolicyType.FullName}'.");
            }
            RetryPolicyType = retryPolicyType;
            return this;
        }
    }
}
