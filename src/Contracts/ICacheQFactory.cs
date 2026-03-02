using Microsoft.Extensions.Logging;
using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Factory that creates configured task dispatchers (parallel, serializable, strict FIFO).
    /// </summary>
    public interface ICacheQFactory
    {
        ICacheQ CacheQ(ILogger<ICacheQ> logger, IDataJobCache payloadLeaseCache, IParallelQ queue);
    }
}
