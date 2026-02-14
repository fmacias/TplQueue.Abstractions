using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// A leased cache entry (read-only + lease token for ack/fail/cancel).
    /// </summary>
    public interface ICacheEntry
    {
        Guid LeaseId { get; }
        Guid JobRootId { get; }
        Guid JobId { get; }
        Guid ParentJobId { get; }
        IJobNodeDto JobNodeDto { get; }
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
        void MarkAck(ISerializable payloadData, IUniversalPayloadSerializer jsonUniversalPayloadSerializer);
        void MarkFailed();
        void MarkCanceled();
        void MarkAsRootSuccessed();
    }
}
