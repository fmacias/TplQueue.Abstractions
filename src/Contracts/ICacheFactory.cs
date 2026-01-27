namespace Fmacias.TplQueue.Contracts
{
    public interface ICacheFactory
    {
        IMemCache CreateMemCache(IPayloadJobFactory payloadRunnerFactory, IJsonUniversalPayloadSerializer serializer);
   }
}
