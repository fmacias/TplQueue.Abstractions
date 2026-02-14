using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Payload serializable con metadatos de enrutamiento para su handler.
    /// </summary>
    public interface IPayload
    {
        Guid HandlerId { get; }
        /// <summary>Identificador lógico del handler (útil para desambiguar en replays/offline).</summary>
        string PayloadId { get; }
        DateTime CollectionTime { get; }
    }
}
