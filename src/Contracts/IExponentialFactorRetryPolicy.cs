using System;

namespace Fmacias.TplQueue.Contracts
{
    public interface IExponentialFactorRetryPolicy : IBackoffRetryPolicy
    {
        double Factor { get; }
    }
}
