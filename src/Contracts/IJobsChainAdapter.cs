namespace Fmacias.TplQueue.Contracts
{
    public interface IJobsChainAdapter: IJobsChain
    {
        IJobsChain GetInnerChain();
    }
}
