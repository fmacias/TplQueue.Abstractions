namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Factory that creates XML serializers for payload data.
    /// </summary>
    public interface IXmlSerializerFactory
    {
        /// <summary>
        /// Creates an XML serializer that can be passed to cache and payload hydration APIs.
        /// </summary>
        /// <returns>An XML serializer that implements <see cref="IXmlUniversalSerializer" />.</returns>
        IXmlUniversalSerializer Serializer();
    }
}
