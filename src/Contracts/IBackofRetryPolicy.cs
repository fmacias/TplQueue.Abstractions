using System;

namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    public interface IBackoffRetryPolicy : IRetryPolicy
    {
        int MaxRetries { get; }
        TimeSpan Delay { get; }
    }
}
