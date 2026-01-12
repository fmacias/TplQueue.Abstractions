namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    public enum TaskRunnerEventStatus
    {
        Cache,
        Enqueueing,
        Enqueued,
        Dequeued,
        Started,
        Running,
        Successed,
        Canceled,
        Failed,
        RootSuccessed,
        Requeuing
    }
}
