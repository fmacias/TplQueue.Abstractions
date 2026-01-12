namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    public interface ICacheFactory
    {
        IMemCache CreateMemCache(IPayloadRunnerFactory payloadRunnerFactory, IUniversalPayloadSerializer serializer);
   }
}
