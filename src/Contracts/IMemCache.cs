namespace Fmacias.TplQueue.Contracts
{
    public interface IMemCache: IPayloadJobCache
    {
        IPayloadJobCache CleanDeleted();
        IPayloadJobCache CleanFinalized();
    }
}
