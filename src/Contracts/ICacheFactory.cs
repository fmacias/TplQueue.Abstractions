namespace Fmacias.TplQueue.Contracts
{
    public interface ICacheFactory<TDataJobCache> where TDataJobCache : IDataJobCache
    {
        /// <summary>
        /// Create a new cache service.
        /// </summary>
        /// <param name="serializer"></param>
        /// <param name="payloadJobFactory"></param>
        /// <param name="typeResolver"></param>
        /// <returns></returns>
        /// <param name="payloadHandlerResolver"></param><param name="retryPolicyAbstractFactory"></param>
        TDataJobCache CreateCache(
            IUniversalDataSerializer serializer,
            IDataJobFactory payloadJobFactory,
            ITypeResolver typeResolver, 
            IPayloadHandlers payloadHandlerResolver, 
            IRetryPolicyAbstractFactory retryPolicyAbstractFactory);
    }
}
