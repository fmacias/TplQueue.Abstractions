using System;

namespace Fmacias.TplQueue.Contracts
{
    public interface IBackoffRetryPolicy : IRetryPolicy
    {
        int MaxRetries { get; }
        TimeSpan Delay { get; }
    }
}
