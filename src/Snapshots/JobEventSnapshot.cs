using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Fmacias.TplQueue.Contracts;

namespace Fmacias.TplQueue.Snapshots
{
    /// <summary>
    /// Immutable, detached event metadata DTO.
    /// Supports JSON serialization and ASP.NET Core request/response binding.
    /// Compatible with C# 7.3 and .NET Standard 2.0.
    /// </summary>
    public sealed class JobEventSnapshot
    {
        public JobEventStatus Status { get; }
        public DateTime Timestamp { get; }
        public int RetryCount { get; }

        /// <summary>Optional execution channel.</summary>
        public int? ExecutionChannel { get; }

        public JobInfoSnapshot JobInfo { get; }

        /// <summary>Exception metadata; None when no exception occurred.</summary>
        public JobExceptionDiagnostic Diagnostic { get; }

        public bool HasException { get { return Diagnostic.HasException; } }

        /// <summary>
        /// Reconstructs the immutable DTO, including from JSON.
        /// Supports System.Text.Json 5.0+ constructor binding without setters.
        /// </summary>
        public JobEventSnapshot(
            JobEventStatus status,
            DateTime timestamp,
            int retryCount,
            int? executionChannel,
            JobInfoSnapshot jobInfo,
            JobExceptionDiagnostic diagnostic)
        {
            Status = status;
            Timestamp = timestamp;
            RetryCount = retryCount;
            ExecutionChannel = executionChannel;
            JobInfo = jobInfo ?? throw new ArgumentNullException(nameof(jobInfo));
            Diagnostic = diagnostic ?? throw new ArgumentNullException(nameof(diagnostic));
        }
    }
}
