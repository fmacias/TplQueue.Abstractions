namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// XML serializer contract for payload data.
    /// </summary>
    /// <remarks>
    /// The concrete XML serializer follows the <see cref="IUniversalDataSerializer" /> contract
    /// while producing XML payload content.
    /// </remarks>
    public interface IXmlUniversalSerializer : IUniversalDataSerializer
    {
    }
}
