using Fmacias.TplQueue.Defaults;
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
        IJobNodeRecord JobNodeRecordDto { get; }
        DateTime CacheUtc { get; }
        bool IsFifo { get; }
        EntryStatus Status { get; }
        IRetryPolicyOptions RetryPolicyOptions { get; }
        bool IsRoot { get; }
        bool Deleted { get; }
        bool RootSuccessed { get; }
        void MarkAsDeleted();
        bool IsFinalized();
        void MarkLeased();
        /// <summary>
        /// Marks the entry as acknowledged and updates its serialized payload content.
        /// </summary>
        /// <param name="payloadData">Serializable payload data produced by execution.</param>
        /// <param name="jsonUniversalPayloadSerializer">
        /// Serializer used to produce the stored payload content. The parameter name is retained for compatibility and
        /// is not limited to JSON.
        /// </param>
        void MarkAck(ISerializable payloadData, IUniversalDataSerializer jsonUniversalPayloadSerializer);
        void MarkFailed();
        void MarkCanceled();
        void MarkAsRootSuccessed();
    }
}
