namespace Fmacias.TplQueue.Contracts
{
    public interface IJobQAdapter: IJobQ
    {
        IJobQ GetInnerQ();
    }
}
