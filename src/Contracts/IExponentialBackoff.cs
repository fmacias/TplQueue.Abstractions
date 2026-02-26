namespace Fmacias.TplQueue.Contracts
{
    public interface IExponentialBackoff : IBackoffRetryPolicy
    {
        double Factor { get; }
    }
}
