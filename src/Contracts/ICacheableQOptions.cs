namespace Fmacias.TplQueue.Contracts
{
    public interface ICacheableQOptions: IQOptions
    {
        IPayloadLeaseCache PayloadLeaseCache { get; }
        IPayloadJobFactory PayloadRunnerFactory { get; }
    }
}
