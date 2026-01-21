using System;
using System.Collections.Generic;

namespace Fmacias.TplQueue.Contracts
{
    public interface IPayloadLeaseCache
    {
        IReadOnlyList<IJobNodeDto> Append<TPayload>(IPayloadJobRoot<TPayload> root, bool isFifo)
            where TPayload : IPayloadCommand;
        bool TryLeaseNextRoot(out IPayloadJobRoot payloadCarrierRoot, out ICacheLeaseEntry lease);
        void AckNode(Guid jobId, ISerializedPayload payloadData);
        void FailNode(Guid jobId, string? errorMessage);
        void CancelNode(Guid jobId);
        void LeaseRootNode(ICacheLeaseEntry leaseEntry);
        void SuccessRootNode(Guid jobRootId);
        bool DeleteRootNode(Guid jobRootId);
        ICacheLeaseEntry GetByJobId(Guid jobId);
        IPayloadLeaseCache CleanDeleted();
        IPayloadLeaseCache CleanFinalized();
    }
}
