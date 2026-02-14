using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Persistence-safe representation of a payload job node.
    /// This contract avoids CLR runtime-only types so records can be stored in durable media.
    /// </summary>
    public interface IJobNodeRecord
    {
        Guid JobId { get; }
        Guid ParentJobId { get; }
        string Name { get; }
        DateTime NodeCreationUtc { get; }
        bool IsRoot { get; }
        bool IsFifo { get; }
        IRetryPolicyDescriptor RetryDescriptor { get; }
        string PayloadTypeName { get; }
        string PayloadJson { get; }
    }
}
