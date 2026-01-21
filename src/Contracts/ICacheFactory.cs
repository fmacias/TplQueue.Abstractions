namespace Fmacias.TplQueue.Contracts
{
    public interface ICacheFactory
    {
        IMemCache CreateMemCache(IPayloadRunnerFactory payloadRunnerFactory, IUniversalPayloadSerializer serializer);
   }
}
