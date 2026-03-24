using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Resolves CLR(Common Language Runtime) payload types from the persisted type identifier.
    /// </summary>
    public interface ITypeResolver
    {
        /// <summary>
        /// Resolves the payload CLR type from a persisted type name.
        /// </summary>
        /// <param name="payloadTypeName">Stored type name.</param>
        /// <returns>Resolved CLR type.</returns>
        Type Resolve(string payloadTypeName);
    }
}
