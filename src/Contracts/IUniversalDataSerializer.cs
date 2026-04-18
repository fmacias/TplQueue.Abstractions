using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Serializes and deserializes payload data once the payload CLR type is already known.
    /// </summary>
    public interface IUniversalDataSerializer
    {
        /// <summary>
        /// Serializes a value using the specified CLR type.
        /// </summary>
        string Serialize(object value, Type type);

        /// <summary>
        /// Deserializes serialized payload content into an instance of the specified CLR type.
        /// </summary>
        /// <param name="json">
        /// Serialized payload content. The parameter name is retained for compatibility and is not limited to JSON.
        /// </param>
        /// <param name="type">Resolved CLR type supplied by the caller.</param>
        object Deserialize(string json, Type type);

        /// <summary>
        /// Serializes a value using its generic CLR type.
        /// </summary>
        string Serialize<T>(T value);

        /// <summary>
        /// Deserializes serialized payload content into the generic CLR type.
        /// </summary>
        /// <param name="json">
        /// Serialized payload content. The parameter name is retained for compatibility and is not limited to JSON.
        /// </param>
        T Deserialize<T>(string json);

        /// <summary>
        /// Serializes the payload carried by a data job node.
        /// </summary>
        string Serialize(IDataJobNode carrier);
    }
}
