using System;
using System.Threading.Tasks;

namespace Fmacias.TplQueue.Contracts
{
    public interface IJob : IJobInfo
    {
        /// <summary>
        /// Specifies that this task must run after the given <paramref name="previousTasks"/>.
        /// Each provided task becomes a dependency of this task.
        /// <param name="previousTasks">Tasks that must complete before this task can run.</param>
        /// </summary>
        IJob After(params IJob[] previousTasks);
        Func<IRetryPolicy> GetRetryPolicyFactory();
        void SetRoot(IJobRoot jobRoot);
        IJob[] GetJobsBatch();
        /// <summary>
        /// Collects the status of the external asynchronus operation related with this object
        /// in order to get awaited.
        /// </summary>
        /// <returns></returns>
        Task WaitUntilFinishedAsync();
        IJobInfo[] GetJobInfoDependencies();

        /// <summary>
        /// Returns an immutable snapshot of this runner's info.
        /// </summary>
        IJobInfo CopyInfo();
    }
}
