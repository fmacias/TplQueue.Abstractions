namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    public interface IDispatcherOptions
    {
        int MaxParallelism { get; }
        int PulseMs { get; }
        string RetryPolicy { get; }
    }
}
