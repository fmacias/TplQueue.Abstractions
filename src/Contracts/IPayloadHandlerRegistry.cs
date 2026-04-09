using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Mutable registration surface used by plugin-style payload handler modules.
    /// </summary>
    public interface IPayloadHandlerRegistry
    {
        /// <summary>
        /// Registers a payload handler instance by its stable plugin-style handler key.
        /// </summary>
        void Register(string payloadHandlerKey, IHandler handler);

        /// <summary>
        /// Registers a payload handler factory by its stable plugin-style handler key.
        /// The factory can resolve handler instances from any IoC container or composition root.
        /// </summary>
        void Register(string payloadHandlerKey, Func<IHandler> handlerFactory);
    }
}
