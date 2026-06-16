using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Compatibility alias for <see cref="IJobInfo"/>.
    /// </summary>
    /// <remarks>
    /// Queue-event and snapshot-facing contracts now standardize on <see cref="IJobInfo"/>.
    /// This alias remains only for compatibility with the preview line.
    /// </remarks>
    [Obsolete("Use IJobInfo directly. IJobInfoDto is a compatibility alias retained from the preview line.")]
    public interface IJobInfoDto: IJobInfo
    {
    }
}
