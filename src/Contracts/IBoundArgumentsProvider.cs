namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    /// <summary>
    /// Internal, optional hook to expose immutable snapshots of the
    /// arguments bound to the runner's handler.
    /// Not part of the public contracts; used by event factories / diagnostics.
    /// </summary>
    public interface IBoundArgumentsProvider
    {
        /// <summary>
        /// Returns a defensive copy of the bound arguments (payloads) if any.
        /// The caller owns the returned array; subsequent Clear() won’t affect it.
        /// </summary>
        object[] GetBoundArgumentsSnapshot();
    }
}
