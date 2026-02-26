namespace Fmacias.TplQueue.Contracts
{
    public interface IJobQAdapter: IQ
    {
        IQ GetInnerQ();
    }
}
