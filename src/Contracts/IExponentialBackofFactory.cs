namespace Fmacias.TplQueue.Contracts
{
    public interface IExponentialBackofFactory: IRetryPolicyFactory<IExponentialBackoff>
    {
        IExponentialBackoff CreateExponentialBackoff(int maxRetries, int delayMs, double factor);
    }
}
