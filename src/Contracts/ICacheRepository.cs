using System;
using System.Linq;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Minimal storage abstraction for cache lease entries.
    /// Implementations may use memory, file-system, sqlite, EF, etc.
    /// </summary>
    public interface ICacheRepository
    {
        /// <summary>
        /// Updates or inserts a lease entry keyed by <see cref="ICacheEntry.JobId"/>.
        /// </summary>
        void Upsert(ICacheEntry entry);

        /// <summary>
        /// Tries to get a lease entry by job id.
        /// </summary>
        bool TryGet(Guid jobId, out ICacheEntry entry);

        /// <summary>
        /// Returns a point-in-time snapshot of all lease entries.
        /// </summary>
        ICacheEntry[] SnapshotAll();

        /// <summary>
        /// Removes a lease entry if it exists.
        /// </summary>
        void TryRemove(Guid jobId);

        ICacheEntry? SelectOldestPendingRoot();
        IOrderedEnumerable<ICacheEntry> SelectPendingChildren(Guid parentJobId);
    }
}
