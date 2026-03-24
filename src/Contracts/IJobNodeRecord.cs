using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Persistence-safe representation of a payload job node.
    /// This contract avoids CLR runtime-only types so records can be stored in durable media.
    /// </summary>
    public interface IJobNodeRecord: IPayloadDeserializable
    {
        Guid JobId { get; }
        Guid ParentJobId { get; }
        Guid PayloadHandlerId { get; }
        string Name { get; }
        DateTime NodeCreationUtc { get; }
        bool IsRoot { get; }
        bool IsFifo { get; }
        string PayloadTypeName { get; }
        string PayloadJson { get; }
        IRetryPolicyOptions RetryPolicyOptions { get; }
        void UpdatePayloadJson(string payloadJson);
    }
}
