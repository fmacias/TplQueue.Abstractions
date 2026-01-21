using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Data Transfer Object (DTO) node used exclusively in the serialization pipeline for payload-based task runners.
    /// Both <see cref="PayloadType"/> and <see cref="PayloadJson"/> are required (non-null).
    /// </summary>
    public interface ITaskRunnerNodeDto
    {
        /// <summary>Unique node identifier.</summary>
        Guid TaskRunnerId { get; }
        Guid ParentTaskRunnerId { get; }
        /// <summary>User-friendly name for diagnostics (optional).</summary>
        string? Name { get; }

        /// <summary>Assembly-qualified payload type name (required).</summary>
        string PayloadType { get; }

        /// <summary>Serialized payload JSON (required, never null).</summary>
        string PayloadJson { get; }

        DateTime NodeCreationUtc { get; }
        bool IsRoot { get; }
        bool IsFifo { get; }
        void UpdatePayloadJson(string payloadJson);
        IRetryPolicyDescriptor RetryDescriptor { get; }
    }
}
