using Microsoft.Extensions.Logging;
using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Factory that creates configured task dispatchers (parallel, serializable, strict FIFO).
    /// </summary>
    public interface ICacheableQFactory
    {
        ICacheablePayloadQ Create(ILogger<ICacheablePayloadQ> logger, IPayloadLeaseCache payloadLeaseCache, IJobQ dispatcher);
    }
}
