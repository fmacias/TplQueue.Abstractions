using System;

namespace Fmacias.TplQueue.Contracts
{
    public interface ICacheEntry
    {
        DateTime EnqueueUtc { get; }
        ITaskGraphDto Graph { get; }
        Guid Id { get; }
    }
}