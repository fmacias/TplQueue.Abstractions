namespace Fmacias.TplQueue.Contracts
{
    public interface IJobsChainAdapter: IJobQ
    {
        IJobQ GetInnerChain();
    }
}
