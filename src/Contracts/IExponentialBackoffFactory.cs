namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Factory contract for exponential-backoff retry policies.
    /// </summary>
    public interface IExponentialBackoffFactory : IRetryPolicyFactory<IExponentialBackoff>
    {
        IExponentialBackoff ExponentialBackoff(int maxRetries, int delayMs, double factor);
    }
}
