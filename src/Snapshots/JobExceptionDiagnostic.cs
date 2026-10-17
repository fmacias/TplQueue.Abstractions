using System;
using System.Collections.Generic;
using System.Linq;

namespace Fmacias.TplQueue.Snapshots
{
    /// <summary>
    /// Immutable exception diagnostic DTO for JSON transport and ASP.NET Core binding.
    /// Contains no references to the original Exception; compatible with C# 7.3.
    /// </summary>
    public sealed class JobExceptionDiagnostic
    {
        /// <summary>Diagnostic used when an event has no exception.</summary>
        public static JobExceptionDiagnostic None { get; } =
            new JobExceptionDiagnostic(
                false,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                0,
                Array.Empty<JobExceptionDiagnostic>());

        public bool HasException { get; }
        public string TypeName { get; }
        public string Message { get; }
        public string StackTrace { get; }
        public string Source { get; }
        public string HelpLink { get; }
        public int HResult { get; }
        public IReadOnlyList<JobExceptionDiagnostic> InnerExceptions { get; }

        /// <summary>
        /// Reconstructs the immutable DTO, including from JSON.
        /// The single public constructor supports System.Text.Json 5.0+
        /// and Json.NET without setters or serializer-specific attributes.
        /// </summary>
        public JobExceptionDiagnostic(
            bool hasException,
            string typeName,
            string message,
            string stackTrace,
            string source,
            string helpLink,
            int hResult,
            IReadOnlyList<JobExceptionDiagnostic> innerExceptions)
        {
            if (innerExceptions == null)
                throw new ArgumentNullException(nameof(innerExceptions));

            var copied = innerExceptions.ToArray();
            
            if (copied.Any(item => item == null))
                throw new ArgumentException(
                    "InnerExceptions must not contain null.",
                    nameof(innerExceptions));

            // Reject contradictory data, including malformed incoming JSON.
            if (!hasException &&
                (!string.IsNullOrEmpty(typeName) ||
                 !string.IsNullOrEmpty(message) ||
                 !string.IsNullOrEmpty(stackTrace) ||
                 !string.IsNullOrEmpty(source) ||
                 !string.IsNullOrEmpty(helpLink) ||
                 hResult != 0 || copied.Length != 0))
            {
                throw new ArgumentException(
                    "A diagnostic without an exception cannot contain exception data.",
                    nameof(hasException));
            }

            HasException = hasException;
            TypeName = typeName ?? string.Empty;
            Message = message ?? string.Empty;
            StackTrace = stackTrace ?? string.Empty;
            Source = source ?? string.Empty;
            HelpLink = helpLink ?? string.Empty;
            HResult = hResult;
            InnerExceptions = Array.AsReadOnly(copied);
        }
    }
}
