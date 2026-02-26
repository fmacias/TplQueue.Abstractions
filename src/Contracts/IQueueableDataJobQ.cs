using System.Threading;

namespace Fmacias.TplQueue.Contracts
{
    public interface IQueueableDataJobQ
    {
        IQ Enqueue<TPayload>(IDataJobRoot<TPayload> jobRoot, CancellationToken ct)
            where TPayload : IPayload;

        IQ EnqueueFifo<TPayload>(IDataJobRoot<TPayload> jobRoot, CancellationToken ct)
            where TPayload : IPayload;
    }
}
