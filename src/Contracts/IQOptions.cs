using System;

namespace Fmacias.TplQueue.Contracts
{
    public interface IQOptions
    {
        Guid Id { get; }
        int MaxParallelism { get; }
        string RetryPolicy { get; }
    }
}
