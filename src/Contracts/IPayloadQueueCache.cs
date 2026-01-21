using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Cache persistente por grafos (root + dependencias).
    /// </summary>
    public interface IPayloadQueueCache
    {
        /// <summary>
        /// Añade un grafo a la cache. Devuelve el Id de la entrada creada.
        /// </summary>
        Task<Guid> AppendAsync(ITaskGraphDto graph, CancellationToken ct);

        /// <summary>Devuelve el siguiente item sin retirarlo (para compatibilidad del adaptador de leases).</summary>
        Task<ICacheEntry?> TryPeekNextAsync(CancellationToken ct);

        /// <summary>Confirma (elimina) una entrada ya procesada.</summary>
        Task AckAsync(Guid id, CancellationToken ct);

        /// <summary>Número de elementos almacenados.</summary>
        Task<long> CountAsync(CancellationToken ct);

        /// <summary>Purgado por antigüedad.</summary>
        Task PurgeExpiredAsync(TimeSpan maxAge, CancellationToken ct);
    }
}
