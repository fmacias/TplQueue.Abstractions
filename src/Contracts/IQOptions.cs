namespace Fmacias.TplQueue.Contracts
{
    public interface IQOptions
    {
        int MaxParallelism { get; }
        string RetryPolicy { get; }
    }
}
