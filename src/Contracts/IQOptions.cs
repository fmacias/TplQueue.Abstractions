namespace Fmacias.TplQueue.Contracts
{
    public interface IQOptions
    {
        int MaxParallelism { get; }
        int PulseMs { get; }
        string RetryPolicy { get; }
    }
}
