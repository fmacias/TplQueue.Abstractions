namespace Fmacias.TplQueue.Contracts
{
    public interface ICacheableQOptions: IQOptions
    {
        IPayloadJobCache PayloadLeaseCache { get; }
        IPayloadJobFactory PayloadRunnerFactory { get; }
    }
}
