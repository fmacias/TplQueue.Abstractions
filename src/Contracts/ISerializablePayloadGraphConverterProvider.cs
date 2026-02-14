using System.Threading;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Provides serialization helpers for payload graphs without requiring a generic class.
    /// Methods are generic so the payload type is known at call site.
    /// </summary>
    public interface ISerializablePayloadGraphConverterProvider
    {
        /// <summary>
        /// Builds a transport DTO for a graph rooted at the given payload task runner.
        /// </summary>
        /// <typeparam name="TPayload">Payload type that implements <see cref="IPayload"/>.</typeparam>
        /// <param name="root">Root node of the payload graph.</param>
        /// 
        /// <returns>A non-generic DTO representing the graph for persistence/rehydration.</returns>
        IJobGraphDto ToDto<TPayload>(IPayloadJobRoot<TPayload> root)
            where TPayload : IPayload;
    }
}
