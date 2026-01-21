using System;
using System.Threading;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Type of <see cref="ITaskRunner"/> can be added to the queue <see cref="ITaskDispatcher"/>
    /// object
    /// </summary>
    public interface ITaskRunnerRoot : ITaskRunner
    {
        /// <summary>
        /// Adds this object to the given <see cref="ITaskDispatcher"/> with the 
        /// provided <see cref="CancellationToken"/>
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        ITaskDispatcher Enqueue(ITaskDispatcher queue, CancellationToken ct);
    }
}
