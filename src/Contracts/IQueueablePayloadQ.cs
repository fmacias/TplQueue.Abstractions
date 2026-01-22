// Abstractions/Contracts/ISerializablePayloadEnqueable.cs
using System.Threading;
using System.Threading.Tasks;

namespace Fmacias.TplQueue.Contracts
{
    public interface IQueueablePayloadQ
    {
        IJobQ Enqueue<TPayload>(IPayloadJobRoot<TPayload> jobRoot, CancellationToken ct)
            where TPayload : IPayloadCommand;

        IJobQ EnqueueFifo<TPayload>(IPayloadJobRoot<TPayload> jobRoot, CancellationToken ct)
            where TPayload : IPayloadCommand;
    }
}
