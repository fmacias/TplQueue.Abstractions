namespace Fmacias.TplQueue.Contracts
{
    /// <summary>Optional execution-slot metadata captured when a lifecycle event is published.</summary>
    /// <remarks>Existing IJobEvent implementations need not implement this interface.
    /// A channel identifies queue capacity, never an OS thread or a root family.
    /// Terminal events retain their execution channel after the runtime releases it.</remarks>
    public interface IJobExecutionEvent : IJobEvent
    {
        /// <summary>Gets the zero-based queue-local channel, or null before execution capacity is assigned.</summary>
        int? ExecutionChannel { get; }
    }
}
