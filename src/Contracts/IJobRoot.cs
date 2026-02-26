using System.Threading;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Type of <see cref="IJob"/> can be added to the queue <see cref="IQ"/>
    /// object
    /// </summary>
    public interface IJobRoot : IJob
    {
        /// <summary>
        /// Adds this object to the given <see cref="IQ"/> with the 
        /// provided <see cref="CancellationToken"/>
        /// </summary>
        /// <param name="jobQ"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        IQ Enqueue(IQ jobQ, CancellationToken ct);
    }
}
