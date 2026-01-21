using Microsoft.Extensions.Logging;
using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Factory that creates configured task dispatchers (parallel, serializable, strict FIFO).
    /// </summary>
    public interface ICacheableChainFactory
    {
        ICacheablePayloadChain Create(ILogger<ICacheablePayloadChain> logger, IPayloadLeaseCache payloadLeaseCache, IJobsChain dispatcher);
    }
}
