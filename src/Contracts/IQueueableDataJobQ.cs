using System.Threading;

namespace Fmacias.TplQueue.Contracts
{
    public interface IQueueableDataJobQ
    {
        ICacheQ Enqueue<TPayload>(IDataJobRoot<TPayload> jobRoot, CancellationToken ct)
            where TPayload : IPayload;

        ICacheQ EnqueueFifo<TPayload>(IDataJobRoot<TPayload> jobRoot, CancellationToken ct)
            where TPayload : IPayload;
    }
}
