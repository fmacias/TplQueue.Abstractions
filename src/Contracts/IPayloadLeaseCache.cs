using System;
using System.Collections.Generic;

namespace Fmacias.TplQueue.Contracts
{
    public interface IPayloadLeaseCache
    {
        IReadOnlyList<ITaskRunnerNodeDto> Append<TPayload>(IPayloadTaskRunnerRoot<TPayload> root, bool isFifo)
            where TPayload : IPayloadCommand;
        bool TryLeaseNextRoot(out IPayloadCarrierRoot payloadCarrierRoot, out ICacheLeaseEntry lease);
        void AckNode(Guid nodeId, ISerializedPayload payloadData);
        void FailNode(Guid nodeId, string? errorMessage);
        void CancelNode(Guid nodeId);
        void LeaseRootNode(ICacheLeaseEntry leaseEntry);
        void SuccessRootNode(Guid taskRunnerRootId);
        bool DeleteRootNode(Guid rootId);
        ICacheLeaseEntry GetByTaskRunnerId(Guid id);
        IPayloadLeaseCache CleanDeleted();
        IPayloadLeaseCache CleanFinalized();
    }
}
