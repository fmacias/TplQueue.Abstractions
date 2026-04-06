namespace Fmacias.TplQueue.Contracts
{
    public interface IJob : IJobNode
    {
        /// <summary>
        /// Specifies that this job must run after the given <paramref name="previousTasks"/>.
        /// Each provided job becomes a dependency of this job.
        /// </summary>
        /// <param name="previousTasks">Jobs that must complete before this job can run.</param>
        IJob After(params IJob[] previousTasks);
    }
}
