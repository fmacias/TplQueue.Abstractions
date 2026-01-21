namespace Fmacias.TplQueue.Contracts
{
    public interface IChainOptions
    {
        int MaxParallelism { get; }
        int PulseMs { get; }
        string RetryPolicy { get; }
    }
}
