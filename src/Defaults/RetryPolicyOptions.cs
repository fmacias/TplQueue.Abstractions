using Fmacias.TplQueue.Contracts;
using System;

namespace Fmacias.TplQueue.Defaults
{
    /// <summary>
    /// Value object describing how to build a retry policy.
    /// <para>If <see cref="MaxRetries"/> is 0 or less, the factory resolves to no retry.</para>
    /// <para>If <see cref="Factor"/> &gt; 0, the factory resolves to exponential backoff.</para>
    /// <para>Otherwise, the factory resolves to linear backoff.</para>
    /// </summary>
    public sealed class RetryPolicyOptions: IRetryPolicyOptions
    {
        public int BaseDelayMs { get; }
        public int MaxRetries { get; }
        public double Factor { get; }

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
    }
}
