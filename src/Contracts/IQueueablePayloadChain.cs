// Abstractions/Contracts/ISerializablePayloadEnqueable.cs
using System.Threading;
using System.Threading.Tasks;

namespace Fmacias.TplQueue.Contracts
{
    public interface IQueueablePayloadChain
    {
        IJobsChain Enqueue<TPayload>(IPayloadJobRoot<TPayload> jobRoot, CancellationToken ct)
            where TPayload : IPayloadCommand;

        IJobsChain EnqueueFifo<TPayload>(IPayloadJobRoot<TPayload> jobRoot, CancellationToken ct)
            where TPayload : IPayloadCommand;
    }
}
