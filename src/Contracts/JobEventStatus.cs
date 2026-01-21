namespace Fmacias.TplQueue.Contracts
{
    public enum JobEventStatus
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
