using System;

namespace Fmacias.TplQueue.Contracts
{
    public interface ICacheEntryFactory
    {
        ICacheEntry CreateEntry(Guid leaseId, Guid jobRootId, IJobNodeRecord jobNodeDto, DateTime cacheUtc);
    }
}
