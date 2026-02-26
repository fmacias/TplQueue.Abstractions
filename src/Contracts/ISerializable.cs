namespace Fmacias.TplQueue.Contracts
{
    public interface ISerializable
    {
        string Serialize(IUniversalDataSerializer serializer);
    }
}
