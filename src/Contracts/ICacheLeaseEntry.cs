using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// A leased cache entry (read-only + lease token for ack/fail/cancel).
    /// </summary>
    public interface ICacheLeaseEntry
    {
        Guid LeaseId { get; }
        Guid TaskRunnerRootId { get; }
        Guid TaskRunnerId { get; }
        Guid ParentTaskRunnerId { get; }
        ITaskRunnerNodeDto TaskRunnerNodeDto { get; }
        DateTime CacheUtc { get; }
        bool IsFifo { get; }
        EntryStatus Status { get; }
        IRetryPolicyDescriptor RetryDescriptor { get; set; }
        bool IsRoot { get; }
        bool Deleted { get; }
        bool RootSuccessed { get; }
        void MarkAsDeleted();
        bool IsFinalized();
        void MarkLeased();
        void MarkAck(ISerializedPayload payloadData);
        void MarkFailed();
        void MarkCanceled();
        void MarkAsRootSuccessed();
    }
}
