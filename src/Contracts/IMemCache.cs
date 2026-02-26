namespace Fmacias.TplQueue.Contracts
{
    public interface IMemCache: IDataJobCache
    {
        IDataJobCache CleanDeleted();
        IDataJobCache CleanFinalized();
    }
}
