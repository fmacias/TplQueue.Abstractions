namespace Fmacias.TplQueue.Contracts
{
    public interface ILinearBackoffFactory : IRetryPolicyFactory<ILinearBackoff>
    {
        ILinearBackoff CreateLienarBackoff(int maxRetries, int delayMs);
    }
}
