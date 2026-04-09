using System.Threading;
using System.Threading.Tasks;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Public payload handler contract resolved from a stable payload handler key.
    /// Implementations can use constructor injection and may ignore the payload when the behavior is service-driven.
    /// </summary>
    public interface IHandler
    {
        /// <summary>
        /// Executes the behavior associated with the resolved payload handler key.
        /// </summary>
        Task HandleAsync(IPayload payload, CancellationToken cancellationToken);
    }
}
