using System;
using System.Threading.Tasks;

namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    public interface ITaskRunner : ITaskRunnerInfo
    {
        /// <summary>
        /// Specifies that this task must run after the given <paramref name="previousTasks"/>.
        /// Each provided task becomes a dependency of this task.
        /// <param name="previousTasks">Tasks that must complete before this task can run.</param>
        /// </summary>
        ITaskRunner After(params ITaskRunner[] previousTasks);
        Func<IRetryPolicy> GetRetryPolicyFactory();
        void SetRoot(ITaskRunnerRoot taskRunnerRoot);
        ITaskRunner[] GetBatch();
        /// <summary>
        /// Collects the status of the external asynchronus operation related with this object
        /// in order to get awaited.
        /// </summary>
        /// <returns></returns>
        Task WaitUntilFinishedAsync();
    }
}
