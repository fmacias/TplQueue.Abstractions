using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Serializable payload with the stable logical identifier used to resolve its handler.
    /// </summary>
    public interface IPayload
    {
        /// <summary>
        /// Stable handler key used by cache hydration and payload-handler resolution.
        /// </summary>
        string PayloadId { get; }

        /// <summary>
        /// Collection timestamp carried by the payload.
        /// </summary>
        DateTime CollectionTime { get; }
    }
}
