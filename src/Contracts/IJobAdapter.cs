namespace Fmacias.TplQueue.Contracts
{
    public interface IJobAdapter: IJobNode
    {
        IJobNode GetInnerJob();
    }
}
