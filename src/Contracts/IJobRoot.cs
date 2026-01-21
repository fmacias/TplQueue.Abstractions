using System;
using System.Threading;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Type of <see cref="IJob"/> can be added to the queue <see cref="IJobsChain"/>
    /// object
    /// </summary>
    public interface IJobRoot : IJob
    {
        /// <summary>
        /// Adds this object to the given <see cref="IJobsChain"/> with the 
        /// provided <see cref="CancellationToken"/>
        /// </summary>
        /// <param name="jobsChain"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        IJobsChain Enqueue(IJobsChain jobsChain, CancellationToken ct);
    }
}
