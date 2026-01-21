// Abstractions/Contracts/IJsonPayloadSerializerFactory.cs
using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Factory that produces a typed IJsonPayloadSerializer&lt;T&gt; instance for a given payload Type.
    /// The returned instance is boxed but implements both IJsonPayloadSerializer&lt;T&gt; and IPayloadSerializer&lt;T&gt;.
    /// </summary>
    public interface IJsonPayloadSerializerFactory
    {
        object Create(Type payloadType);
    }
}
