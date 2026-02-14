using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Resolves a handler delegate for a payload type (and optional handler id).
    /// </summary>
    public interface IJobHandlerResolver
    {
        /// <summary>
        /// Returns an untyped handler that accepts (object payload, CancellationToken ct).
        /// </summary>
        Func<CancellationToken, Task> Resolve(Type payloadType, string handlerId);
    }
}
