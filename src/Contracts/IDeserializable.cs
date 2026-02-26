namespace Fmacias.TplQueue.Contracts
{
    public interface IDeserializable
    {
        object Deserialize(IUniversalDataSerializer serializer);
        T Deserialize<T>(IUniversalDataSerializer serializer);
    }
}
