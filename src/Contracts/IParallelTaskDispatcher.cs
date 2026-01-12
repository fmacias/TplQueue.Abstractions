using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    public interface IParallelTaskDispatcher: ITaskDispatcher
    {
        IParallelTaskDispatcher Enqueue(Action<CancellationToken> action, CancellationToken ct, string name = "", Func<IRetryPolicy>? retryPolicyFactory = null);
        IParallelTaskDispatcher Enqueue(Func<CancellationToken, Task> func, CancellationToken ct, string name = "", Func<IRetryPolicy>? retryPolicyFactory = null);
        IParallelTaskDispatcher Enqueue<T>(Action<CancellationToken, T> action, T arg, CancellationToken ct, string name = "", Func<IRetryPolicy>? retryPolicyFactory = null);
        IParallelTaskDispatcher Enqueue<T>(Func<CancellationToken, T, Task> func, T arg, CancellationToken ct, string name = "", Func<IRetryPolicy>? retryPolicyFactory = null);
        IParallelTaskDispatcher Enqueue<T1, T2>(Action<CancellationToken, T1, T2> action, T1 arg1, T2 arg2, CancellationToken ct, string name = "", Func<IRetryPolicy>? retryPolicyFactory = null);
        IParallelTaskDispatcher Enqueue<T1, T2>(Func<CancellationToken, T1, T2, Task> func, T1 arg1, T2 arg2, CancellationToken ct, string name = "", Func<IRetryPolicy>? retryPolicyFactory = null);
        IParallelTaskDispatcher EnqueueFifo(Action<CancellationToken> action, CancellationToken ct, string name = "", Func<IRetryPolicy>? retryPolicyFactory = null);
        IParallelTaskDispatcher EnqueueFifo(Func<CancellationToken, Task> func, CancellationToken ct, string name = "", Func<IRetryPolicy>? retryPolicyFactory = null);
        IParallelTaskDispatcher EnqueueFifo<T>(Action<CancellationToken, T> action, T arg, CancellationToken ct, string name = "", Func<IRetryPolicy>? retryPolicyFactory = null);
        IParallelTaskDispatcher EnqueueFifo<T>(Func<CancellationToken, T, Task> func, T arg, CancellationToken ct, string name = "", Func<IRetryPolicy>? retryPolicyFactory = null);
        IParallelTaskDispatcher EnqueueFifo<T1, T2>(Action<CancellationToken, T1, T2> action, T1 arg1, T2 arg2, CancellationToken ct, string name = "", Func<IRetryPolicy>? retryPolicyFactory = null);
        IParallelTaskDispatcher EnqueueFifo<T1, T2>(Func<CancellationToken, T1, T2, Task> func, T1 arg1, T2 arg2, CancellationToken ct, string name = "", Func<IRetryPolicy>? retryPolicyFactory = null);
    }
}
