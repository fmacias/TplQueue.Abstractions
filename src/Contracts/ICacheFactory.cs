namespace Fmacias.TplQueue.Contracts
{
    public interface ICacheFactory<TJobCache> where TJobCache : IDataJobCache
    {
        /// <summary>
        /// Create a new cache service.
        /// Notice that <see cref="ICacheRepository"/>, <see cref="INodeTypeResolver"/> and <see cref="INodeTypeResolver"/>
        /// parameters are made optional. May be you are not interested to expose the services related with
        /// and the implementation are internal visible to its corresponding module.
        /// </summary>
        /// <param name="serializer"></param>
        /// <param name="payloadJobFactory"></param>
        /// <param name="typeResolver"></param>
        /// <returns></returns>
        TJobCache CreateCache(
            IUniversalDataSerializer serializer,
            IDataJobFactory payloadJobFactory,
            INodeTypeResolver typeResolver);
    }
}
