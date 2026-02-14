namespace Fmacias.TplQueue.Contracts
{
    public interface IDeserializable
    {
        object Deserialize(IUniversalPayloadSerializer serializer);
        T Deserialize<T>(IUniversalPayloadSerializer serializer);
    }
}
