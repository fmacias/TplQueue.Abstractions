namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    public interface ITaskRunnerAdapter: ITaskRunner
    {
        ITaskRunner GetInnerRunner();
    }
}
