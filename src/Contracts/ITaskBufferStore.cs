using System;
using System.Collections.Generic;

namespace Fmacias.TplQueue.Contracts
{
    public interface ITaskBufferStore
    {
        // Inserta/actualiza snapshot serializable del nodo
        System.Threading.Tasks.Task UpsertAsync(
            Guid runnerId,
            string name,
            string handlerId,
            string payloadType,
            string payloadJson,
            JobEventStatus lastStatus,
            DateTime timestamp);

        // Devuelve items pendientes por ejecutar (ordenable por timestamp/dep)
        IAsyncEnumerable<(Guid Id, string Name, string HandlerId, string PayloadType, string PayloadJson)> DequeueBatchAsync(int take, System.Threading.CancellationToken ct);
        System.Threading.Tasks.Task RemoveAsync(Guid runnerId);
        // … y lo que veas necesario (marcar fallos, reintentos, etc.)
    }
}
