namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// High-level API (facade) to construct dispatchers, retry policies, and jobs
    /// using the registered factories. This type does not execute work; it only creates
    /// configured instances for consumption.
    /// </summary>
    public interface ICoreApi
    {
        IQFactory QFactory { get; }
        IJobFactory JobFactory { get; }
        IDataJobFactory DataJobFactory { get; }
    }
}
