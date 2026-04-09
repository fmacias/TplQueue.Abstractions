namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Plugin-style module that contributes one or more payload handler registrations.
    /// </summary>
    public interface IPayloadHandlerPlugin
    {
        /// <summary>
        /// Registers the payload handlers exposed by this plugin.
        /// </summary>
        void Register(IPayloadHandlerRegistry registry);
    }
}
