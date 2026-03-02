namespace Fmacias.TplQueue.Contracts
{
    public interface ICacheQ: IParallelQ, IQueueableDataJobQ
    {
        int LeasingPulseMs { get; set; }
    }
}
