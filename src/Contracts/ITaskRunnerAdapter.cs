namespace Fmacias.TplQueue.Contracts
{
    public interface ITaskRunnerAdapter: ITaskRunner
    {
        ITaskRunner GetInnerRunner();
    }
}
