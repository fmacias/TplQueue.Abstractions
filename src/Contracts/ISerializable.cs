namespace Fmacias.TplQueue.Contracts
{
    public interface ISerializable
    {
        string Serialize(IUniversalPayloadSerializer serializer);
    }
}
