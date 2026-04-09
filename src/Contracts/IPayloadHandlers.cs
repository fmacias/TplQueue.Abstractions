namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Resolves payload handlers from the persisted stable payload handler key.
    /// </summary>
    public interface IPayloadHandlers
    {
        /// <summary>
        /// Resolves a payload handler from the persisted payload handler key.
        /// </summary>
        /// <param name="payloadHandlerKey">Stable plugin-style handler identifier.</param>
        /// <returns>The registered handler.</returns>
        IHandler Handler(string payloadHandlerKey);
    }
}
