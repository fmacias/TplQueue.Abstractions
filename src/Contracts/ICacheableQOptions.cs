namespace Fmacias.TplQueue.Contracts
{
    public interface ICacheableQOptions: IQOptions
    {
        IDataJobCache PayloadLeaseCache { get; }
        /// <summary>
        /// Factory used to rehydrate payload-aware jobs for cache-backed queue flows.
        /// </summary>
        /// <remarks>
        /// The property name is retained for compatibility with the preview line.
        /// </remarks>
        IDataJobFactory PayloadRunnerFactory { get; }
    }
}
