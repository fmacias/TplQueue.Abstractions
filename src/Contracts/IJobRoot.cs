using System;
using System.Threading;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Type of <see cref="IJob"/> can be added to the queue <see cref="IJobQ"/>
    /// object
    /// </summary>
    public interface IJobRoot : IJob
    {
        /// <summary>
        /// Adds this object to the given <see cref="IJobQ"/> with the 
        /// provided <see cref="CancellationToken"/>
        /// </summary>
        /// <param name="jobQ"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        IJobQ Enqueue(IJobQ jobQ, CancellationToken ct);
    }
}
