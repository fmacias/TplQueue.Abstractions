namespace Fmacias.TplQueue.Contracts
{
    public interface IParallelJobQAdapter: IParallelQ
    {
        IParallelQ GetInnerQ();
    }
}
