using System;

namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    public interface IExponentialFactorRetryPolicy : IBackoffRetryPolicy
    {
        double Factor { get; }
    }
}
