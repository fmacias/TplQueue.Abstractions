using Fmaciasruano.TplQueue.Abstractions.Contracts;
using System;

namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    public interface ICacheEntry
    {
        DateTime EnqueueUtc { get; }
        ITaskGraphDto Graph { get; }
        Guid Id { get; }
    }
}