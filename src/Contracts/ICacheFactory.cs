namespace Fmacias.TplQueue.Contracts
{
    public interface ICacheFactory
    {
        IMemCache CreateMemCache(IPayloadJobFactory payloadRunnerFactory, 
            IUniversalPayloadSerializer serializer, ICacheEntryFactory cacheFacade);
   }
}
