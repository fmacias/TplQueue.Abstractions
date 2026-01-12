// File: Abstractions/Contracts/IQueueCommand.cs
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    /// <summary>
    /// Marca para payloads serializables que se encolan.
    /// Debe incluir un identificador de handler y su instante de encolado.
    /// </summary>
    public interface IQueueCommand
    {
        string HandlerId { get; }
        DateTime EnqueueUtc { get; }
    }

    /// <summary>
    /// Variante auto-ejecutable (si prefieres que el payload se ejecute solo).
    /// </summary>
    public interface IExecutableQueueCommand : IQueueCommand
    {
        Task ExecuteAsync(object? services, CancellationToken ct);
    }
}
