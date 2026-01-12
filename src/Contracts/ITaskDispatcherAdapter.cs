namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    public interface ITaskDispatcherAdapter: ITaskDispatcher
    {
        ITaskDispatcher GetInnerQueue();
    }
}
