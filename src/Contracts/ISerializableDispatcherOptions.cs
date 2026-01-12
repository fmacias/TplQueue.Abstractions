namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    public interface ISerializableDispatcherOptions: IDispatcherOptions
    {
        IPayloadLeaseCache PayloadLeaseCache { get; }
        IPayloadRunnerFactory PayloadRunnerFactory { get; }
    }
}
