using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Persistence-safe representation of a payload job node.
    /// This contract avoids CLR runtime-only types so records can be stored in durable media.
    /// </summary>
    public interface IJobNodeRecord : IPayloadDeserializable
    {
        Guid JobId { get; }
        Guid ParentJobId { get; }
        string PayloadHandlerKey { get; }
        string Name { get; }
        DateTime NodeCreationUtc { get; }
        bool IsRoot { get; }
        bool IsFifo { get; }
        string PayloadTypeName { get; }
        /// <summary>
        /// Serialized payload content.
        /// </summary>
        /// <remarks>
        /// The value is produced by the configured <see cref="IUniversalDataSerializer"/> and can
        /// contain JSON, XML, or another supported serialized format.
        /// </remarks>
        string SerializedPayload { get; }
        IRetryPolicyOptions RetryPolicyOptions { get; }
        /// <summary>
        /// Replaces the serialized payload content stored in <see cref="SerializedPayload"/>.
        /// </summary>
        /// <param name="serializedPayload">
        /// Serialized payload content. The format is serializer-specific and is not limited to JSON.
        /// </param>
        void UpdateSerializedPayload(string serializedPayload);
    }
}
