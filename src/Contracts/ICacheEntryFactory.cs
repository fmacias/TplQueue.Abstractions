using System;

namespace Fmacias.TplQueue.Contracts
{
    public interface ICacheEntryFactory
    {
        ICacheEntry CreateCacheEntry(Guid leaseId, Guid jobRootId, IJobNodeDto jobNodeDto, DateTime cacheUtc);
    }
}