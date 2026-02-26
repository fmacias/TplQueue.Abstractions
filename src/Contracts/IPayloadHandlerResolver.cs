using System;
using System.Threading;
namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Resolves a handler delegate for a payload type (and optional handler id).
    /// </summary>
    public interface IPayloadHandlerResolver
    {
        /// <summary>
        /// Returns an untyped handler that accepts (object payload, CancellationToken ct).
        /// </summary>
        IUniversaPayloadHandler Resolve(Guid handlerId);
    }
}
