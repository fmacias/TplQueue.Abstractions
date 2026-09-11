using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Serializable payload carrying its instance identity and handler-routing key.
    /// </summary>
    public interface IPayload
    {
        /// <summary>
        /// Stable identifier for this payload instance.
        /// </summary>
        string PayloadId { get; }

        /// <summary>
        /// Collection timestamp carried by the payload.
        /// </summary>
        DateTime CollectionTime { get; }

        /// <summary>
        /// Stable key used to resolve the handler for this payload type.
        /// </summary>
        string HandlerKey { get; }
    }
}
