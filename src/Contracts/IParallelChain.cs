using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fmacias.TplQueue.Contracts
{
    public interface IParallelChain: IJobsChain
    {
        IParallelChain Enqueue(Action<CancellationToken> action, CancellationToken ct, string name = "", Func<IRetryPolicy>? retryPolicyFactory = null);
        IParallelChain Enqueue(Func<CancellationToken, Task> func, CancellationToken ct, string name = "", Func<IRetryPolicy>? retryPolicyFactory = null);
        IParallelChain Enqueue<T>(Action<CancellationToken, T> action, T arg, CancellationToken ct, string name = "", Func<IRetryPolicy>? retryPolicyFactory = null);
        IParallelChain Enqueue<T>(Func<CancellationToken, T, Task> func, T arg, CancellationToken ct, string name = "", Func<IRetryPolicy>? retryPolicyFactory = null);
        IParallelChain Enqueue<T1, T2>(Action<CancellationToken, T1, T2> action, T1 arg1, T2 arg2, CancellationToken ct, string name = "", Func<IRetryPolicy>? retryPolicyFactory = null);
        IParallelChain Enqueue<T1, T2>(Func<CancellationToken, T1, T2, Task> func, T1 arg1, T2 arg2, CancellationToken ct, string name = "", Func<IRetryPolicy>? retryPolicyFactory = null);
        IParallelChain EnqueueFifo(Action<CancellationToken> action, CancellationToken ct, string name = "", Func<IRetryPolicy>? retryPolicyFactory = null);
        IParallelChain EnqueueFifo(Func<CancellationToken, Task> func, CancellationToken ct, string name = "", Func<IRetryPolicy>? retryPolicyFactory = null);
        IParallelChain EnqueueFifo<T>(Action<CancellationToken, T> action, T arg, CancellationToken ct, string name = "", Func<IRetryPolicy>? retryPolicyFactory = null);
        IParallelChain EnqueueFifo<T>(Func<CancellationToken, T, Task> func, T arg, CancellationToken ct, string name = "", Func<IRetryPolicy>? retryPolicyFactory = null);
        IParallelChain EnqueueFifo<T1, T2>(Action<CancellationToken, T1, T2> action, T1 arg1, T2 arg2, CancellationToken ct, string name = "", Func<IRetryPolicy>? retryPolicyFactory = null);
        IParallelChain EnqueueFifo<T1, T2>(Func<CancellationToken, T1, T2, Task> func, T1 arg1, T2 arg2, CancellationToken ct, string name = "", Func<IRetryPolicy>? retryPolicyFactory = null);
    }
}
