using System.Threading;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Enqueueable root job for a composed job graph.
    /// The root is the terminal node of the graph and is the element submitted to an <see cref="IQ"/>.
    /// </summary>
    public interface IJobRoot : IJobNode
    {
        /// <summary>
        /// Specifies that this root must run after the given <paramref name="previousTasks"/>.
        /// A root may depend on non-root jobs or previous roots.
        /// </summary>
        /// <param name="previousTasks">Nodes that must complete before this root can run.</param>
        IJobRoot After(params IJobNode[] previousTasks);

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
