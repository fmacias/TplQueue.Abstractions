using Fmacias.TplQueue.Snapshots;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Creates immutable snapshots from observed job events.
    /// </summary>
    public interface IJobEventSnapshotFactory
    {
        JobEventSnapshot Capture(IJobEvent source);
    }
}
