namespace Fmacias.TplQueue.Contracts
{
    public interface IJobAdapter: IJob
    {
        IJob GetInnerJob();
    }
}
