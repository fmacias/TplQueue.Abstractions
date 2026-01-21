namespace Fmacias.TplQueue.Contracts
{
    public interface IDispatcherOptions
    {
        int MaxParallelism { get; }
        int PulseMs { get; }
        string RetryPolicy { get; }
    }
}
