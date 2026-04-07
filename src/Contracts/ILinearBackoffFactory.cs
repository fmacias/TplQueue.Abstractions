namespace Fmacias.TplQueue.Contracts
{
    public interface ILinearBackoffFactory : IRetryPolicyFactory<ILinearBackoff>
    {
        ILinearBackoff LinearBackoff(int maxRetries, int delayMs);
    }
}
