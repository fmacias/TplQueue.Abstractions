using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Marker for serializable queue commands carrying their stable payload handler key.
    /// </summary>
    public interface IQueueCommand
    {
        string PayloadId { get; }
        DateTime EnqueueUtc { get; }
    }

    /// <summary>
    /// Self-executable queue command variant.
    /// </summary>
    public interface IExecutableQueueCommand : IQueueCommand
    {
        Task ExecuteAsync(object? services, CancellationToken ct);
    }
}
