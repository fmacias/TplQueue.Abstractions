namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Factory contract for exponential-backoff retry policies.
    /// </summary>
    /// <remarks>
    /// The public type name is retained for compatibility with the preview line and is not being
    /// renamed as part of the first stable API freeze.
    /// </remarks>
    public interface IExponentialBackofFactory: IRetryPolicyFactory<IExponentialBackoff>
    {
        IExponentialBackoff ExponentialBackof(int maxRetries, int delayMs, double factor);
    }
}
