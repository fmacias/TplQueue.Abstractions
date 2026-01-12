// Abstractions/Contracts/ISerializablePayloadEnqueable.cs
using System.Threading;
using System.Threading.Tasks;

namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    public interface ISerializablePayloadEnqueable
    {
        ITaskDispatcher Enqueue<TPayload>(IPayloadTaskRunnerRoot<TPayload> taskRunnerRoot, CancellationToken ct)
            where TPayload : IPayloadCommand;

        ITaskDispatcher EnqueueFifo<TPayload>(IPayloadTaskRunnerRoot<TPayload> taskRunnerRoot, CancellationToken ct)
            where TPayload : IPayloadCommand;
    }
}
