namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Payload-aware job information surface for live <see cref="IDataJob"/> and
    /// <see cref="IDataJobRoot"/> instances, or for explicit consumer-side transport projections.
    /// </summary>
    /// <remarks>
    /// <see cref="IJobEvent.JobInfo"/> is not required to implement this interface. Queue event
    /// publications may expose metadata-only <see cref="IJobInfo"/> snapshots to avoid retaining
    /// live payload object graphs in observer buffers.
    /// </remarks>
    public interface IDataJobInfo : IJobInfo, ISerializable
    {
        /// <summary>
        /// Stable payload handler key persisted with dehydrated payload jobs.
        /// </summary>
        string PayloadHandlerKey { get; }
    }
}
