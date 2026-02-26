namespace Fmacias.TplQueue.Contracts
{
    public interface ICacheQ: IQ, IQueueableDataJobQ
    {
        int LeasingPulseMs { get; set; }
    }
}
