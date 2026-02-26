namespace Fmacias.TplQueue.Contracts
{
    public interface ICacheableQOptions: IQOptions
    {
        IDataJobCache PayloadLeaseCache { get; }
        IDataJobFactory PayloadRunnerFactory { get; }
    }
}
