namespace Fmacias.TplQueue.Contracts
{
    public interface IExponentialBackofFactory: IRetryPolicyFactory<IExponentialBackoff>
    {
        IExponentialBackoff ExponentialBackof(int maxRetries, int delayMs, double factor);
    }
}
