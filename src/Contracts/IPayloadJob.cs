namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Strongly-typed view of a payload-carrying task runner.
    /// Inherits <see cref="IPayloadCarrier{T}"/> so generic infrastructure can
    /// access payloads without knowing <typeparamref name="T"/>.
    /// </summary>
    public interface IPayloadJob<T> : IPayloadCarrier<T>, IJob
        where T : IPayload
    {
    }
}
