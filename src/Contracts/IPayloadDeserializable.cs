namespace Fmacias.TplQueue.Contracts
{
    public interface IPayloadDeserializable
    {
        object Deserialize(IUniversalDataSerializer serializer);
        T Deserialize<T>(IUniversalDataSerializer serializer);
    }
}
