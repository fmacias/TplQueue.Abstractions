using System;

namespace Fmacias.TplQueue.Contracts
{
    public interface IExponentialBackoffRetryPolicy : IBackoffRetryPolicy
    {
        double Factor { get; }
    }
}
