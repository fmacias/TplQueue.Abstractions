using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fmacias.TplQueue.Contracts
{
    public interface IJobRootFactory
    {
        IJobRoot JobRoot(Action<CancellationToken> body, Func<IRetryPolicy>? retryPolicyFactory = null, string name = "");
        IJobRoot JobRoot(Func<CancellationToken, Task> body, Func<IRetryPolicy>? retryPolicyFactory = null, string name = "");
        IJobRoot JobRoot(Guid id, Action<CancellationToken> body, Func<IRetryPolicy>? retryPolicyFactory = null, string name = "");
        IJobRoot JobRoot(Guid id, Func<CancellationToken, Task> body, Func<IRetryPolicy>? retryPolicyFactory = null, string name = "");
        IJobRoot JobRoot<T>(Action<CancellationToken, T> body, T arg, Func<IRetryPolicy>? retryPolicyFactory = null, string name = "");
        IJobRoot JobRoot<T>(Func<CancellationToken, T, Task> body, T arg, Func<IRetryPolicy>? retryPolicyFactory = null, string name = "");
        IJobRoot JobRoot<T>(Guid id, Action<CancellationToken, T> body, T arg, Func<IRetryPolicy>? retryPolicyFactory = null, string name = "");
        IJobRoot JobRoot<T>(Guid id, Func<CancellationToken, T, Task> body, T arg, Func<IRetryPolicy>? retryPolicyFactory = null, string name = "");
        IJobRoot JobRoot<T1, T2>(Action<CancellationToken, T1, T2> body, T1 arg1, T2 arg2, Func<IRetryPolicy>? retryPolicyFactory = null, string name = "");
        IJobRoot JobRoot<T1, T2>(Func<CancellationToken, T1, T2, Task> body, T1 arg1, T2 arg2, Func<IRetryPolicy>? retryPolicyFactory = null, string name = "");
        IJobRoot JobRoot<T1, T2>(Guid id, Action<CancellationToken, T1, T2> body, T1 arg1, T2 arg2, Func<IRetryPolicy>? retryPolicyFactory = null, string name = "");
        IJobRoot JobRoot<T1, T2>(Guid id, Func<CancellationToken, T1, T2, Task> body, T1 arg1, T2 arg2, Func<IRetryPolicy>? retryPolicyFactory = null, string name = "");
    }
}
