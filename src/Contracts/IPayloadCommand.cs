namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Payload serializable que contiene su propio handler (command pattern).
    /// </summary>
    public interface IPayloadCommand
    {
        /// <summary>Identificador lógico del handler (útil para desambiguar en replays/offline).</summary>
        string HandlerId { get; }

        /// <summary>Ejecuta el comando.</summary>
        System.Threading.Tasks.Task ExecuteAsync(System.Threading.CancellationToken ct);
    }
}
