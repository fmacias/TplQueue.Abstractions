using Microsoft.Extensions.Logging;
using System;

namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    /// <summary>
    /// Factory that creates configured task dispatchers (parallel, serializable, strict FIFO).
    /// </summary>
    public interface ISerializableDispatcherFactory
    {
        ISerializablePayloadDispatcher Create(ILogger<ISerializablePayloadDispatcher> logger, IPayloadLeaseCache payloadLeaseCache, ITaskDispatcher dispatcher);
    }
}
