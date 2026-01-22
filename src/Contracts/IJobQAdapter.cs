namespace Fmacias.TplQueue.Contracts
{
    public interface IJobQAdapter: IJobQ
    {
        IJobQ GetInnerChain();
    }
}
