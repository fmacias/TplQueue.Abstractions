namespace Fmacias.TplQueue.Contracts
{
    public interface ITaskDispatcherAdapter: ITaskDispatcher
    {
        ITaskDispatcher GetInnerQueue();
    }
}
