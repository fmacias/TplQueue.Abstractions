using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fmacias.TplQueue.Contracts;

namespace Fmacias.TplQueue.Snapshots
{
    /// <summary>
    /// Immutable, detached job metadata DTO, including dependencies.
    /// Supports JSON transport and ASP.NET Core request/response binding.
    /// Compatible with C# 7.3 and .NET Standard 2.0.
    /// </summary>
    public sealed class JobInfoSnapshot
    {
        public Guid Id { get; }
        public string Name { get; }
        public bool IsCompleted { get; }
        public DateTime ExecutionStart { get; }
        public TimeSpan ExecutionTime { get; }
        public DateTime ExecutionEnd { get; }
        public TaskStatus Status { get; }
        public Guid CrossQueueId { get; }

        /// <summary>Detached, read-only dependency snapshots.</summary>
        public IReadOnlyList<JobInfoSnapshot> Dependencies { get; }

        /// <summary>
        /// Reconstructs an immutable DTO, including from JSON.
        /// Supports System.Text.Json 5.0+ constructor binding without setters.
        /// </summary>
        public JobInfoSnapshot(
            Guid id,
            string name,
            bool isCompleted,
            DateTime executionStart,
            TimeSpan executionTime,
            DateTime executionEnd,
            TaskStatus status,
            Guid crossQueueId,
            IReadOnlyList<JobInfoSnapshot> dependencies)
        {
            if (dependencies == null)
                throw new ArgumentNullException(nameof(dependencies));

            // Do not retain the caller's collection, including after deserialization.
            var copied = dependencies.ToArray();
            if (copied.Any(item => item == null))
                throw new ArgumentException(
                    "Dependencies must not contain null.", nameof(dependencies));

            Id = id;
            Name = name ?? string.Empty;
            IsCompleted = isCompleted;
            ExecutionStart = executionStart;
            ExecutionTime = executionTime;
            ExecutionEnd = executionEnd;
            Status = status;
            CrossQueueId = crossQueueId;
            Dependencies = Array.AsReadOnly(copied);
        }
    }
}
