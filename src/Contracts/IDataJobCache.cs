using System;
using System.Collections.Generic;

namespace Fmacias.TplQueue.Contracts
{
    public interface IDataJobCache
    {
        /// <summary>
        /// Dehydrates a payload job graph into DTO nodes that can be persisted by any cache store.
        /// Concretlly Traverses a payload graph and returns its serialized DTO nodes.
        /// </summary>
        /// <typeparam name="TPayload"></typeparam>
        /// <param name="root"></param>
        /// <param name="isFifo"></param>
        /// <returns></returns>
        IReadOnlyList<IJobNodeDto> Dehydrate<TPayload>(IDataJobRoot<TPayload> root, bool isFifo)
            where TPayload : IPayload;

        /// <summary>
        /// Hydrates the next cached node and all pending descendants into an 
        /// executable payload graph.
        /// </summary>
        /// <param name="payloadJobRoot"></param>
        /// <param name="lease"></param>
        /// <returns></returns>
        bool TryHydrateNextJob(out IDataJobRoot payloadJobRoot, out ICacheEntry lease);

        /// <summary>
        /// Mark as acknowledged with its related serializable data
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="payloadData"></param>
        void AckNode(Guid jobId, ISerializable payloadData);
        
        /// <summary>
        /// Mark as failured
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="errorMessage"></param>
        void FailNode(Guid jobId, string? errorMessage);

        /// <summary>
        /// Mark as canceled
        /// </summary>
        /// <param name="jobId"></param>
        void CancelNode(Guid jobId);

        /// <summary>
        /// Mark as leased.
        /// </summary>
        /// <param name="leaseEntry"></param>
        void LeaseRootNode(ICacheEntry leaseEntry);
        
        /// <summary>
        /// Mark root graph node as successed
        /// </summary>
        /// <param name="jobRootId"></param>
        void SuccessRootNode(Guid jobRootId);
        /// <summary>
        /// Delete root graph node
        /// </summary>
        /// <param name="jobRootId"></param>
        /// <returns></returns>
        bool DeleteRootNode(Guid jobRootId);

        /// <summary>
        /// Get cache entry by job id
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        ICacheEntry GetByJobId(Guid jobId);
    }
}
