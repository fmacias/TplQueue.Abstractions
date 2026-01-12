namespace Fmaciasruano.TplQueue.Abstractions
{
    /// <summary>
    /// Value object describing how to build a retry policy.
    /// <para>If <see cref="Factor"/> is <c>null</c> → Linear backoff.</para>
    /// <para>If <see cref="Factor"/> &gt; 0 → Exponential backoff.</para>
    /// </summary>
    public sealed class RetryPolicyOptions
    {
        public int BaseDelayMs { get; private set; }
        public int MaxRetries { get; private set; }
        public double? Factor { get; private set; }

        public RetryPolicyOptions(int baseDelayMs, int maxRetries, double? factor)
        {
            if (baseDelayMs < 0) throw new System.ArgumentOutOfRangeException(nameof(baseDelayMs));
            if (maxRetries < 0) throw new System.ArgumentOutOfRangeException(nameof(maxRetries));
            if (factor.HasValue && factor.Value <= 0d) throw new System.ArgumentOutOfRangeException(nameof(factor));
            if (maxRetries > 0 && baseDelayMs <= 0) throw new System.ArgumentOutOfRangeException(nameof(baseDelayMs));

            BaseDelayMs = baseDelayMs;
            MaxRetries = maxRetries;
            Factor = factor;
        }

        public static RetryPolicyOptions Linear(int baseDelayMs, int maxRetries)
            => new RetryPolicyOptions(baseDelayMs, maxRetries, factor: null);

        public static RetryPolicyOptions Exponential(int baseDelayMs, int maxRetries, double factor = 2.0)
            => new RetryPolicyOptions(baseDelayMs, maxRetries, factor);
    }
}
