namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Serializes the current state of a live payload-owning object through the provided serializer.
    /// </summary>
    public interface ISerializable
    {
        string Serialize(IUniversalDataSerializer serializer);
    }
}
