using System;
using System.Threading.Tasks;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Shared runtime contract for nodes that participate in a composed job graph.
    /// Both <see cref="IJob"/> and <see cref="IJobRoot"/> expose this common execution state.
    /// </summary>
    public interface IJobNode : IJobInfo
    {
        Func<IRetryPolicy> GetRetryPolicyFactory();
        void SetRoot(IJobRoot jobRoot);
        IJobNode[] GetJobsBatch();

        /// <summary>
        /// Exposes the external asynchronous operation associated with this node so callers can await completion.
        /// </summary>
        Task WaitUntilFinishedAsync();
        IJobInfo[] GetJobInfoDependencies();

        /// <summary>
        /// Returns an immutable snapshot of this job node's info.
        /// </summary>
        IJobInfo CopyInfo();
    }
}
