namespace Fmacias.TplQueue.Contracts
{
    public interface ICacheableChainOptions: IChainOptions
    {
        IPayloadLeaseCache PayloadLeaseCache { get; }
        IPayloadJobFactory PayloadRunnerFactory { get; }
    }
}
