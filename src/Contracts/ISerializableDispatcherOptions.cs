namespace Fmacias.TplQueue.Contracts
{
    public interface ISerializableDispatcherOptions: IDispatcherOptions
    {
        IPayloadLeaseCache PayloadLeaseCache { get; }
        IPayloadRunnerFactory PayloadRunnerFactory { get; }
    }
}
