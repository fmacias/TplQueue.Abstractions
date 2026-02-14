namespace Fmacias.TplQueue.Contracts
{
    public interface ISerializedPayloadFactory
    {
        ISerializedPayload Create(IPayload payload, IJsonUniversalPayloadSerializer serializer);
    }
}
