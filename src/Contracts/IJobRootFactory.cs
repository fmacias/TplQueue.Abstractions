using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fmacias.TplQueue.Contracts
{
    public interface IJobRootFactory
    {
        IJobRoot Create(Action<CancellationToken> body, Func<IRetryPolicy>? retryPolicyFactory = null, string name = "");
        IJobRoot Create(Func<CancellationToken, Task> body, Func<IRetryPolicy>? retryPolicyFactory = null, string name = "");
        IJobRoot Create(Guid id, Action<CancellationToken> body, Func<IRetryPolicy>? retryPolicyFactory = null, string name = "");
        IJobRoot Create(Guid id, Func<CancellationToken, Task> body, Func<IRetryPolicy>? retryPolicyFactory = null, string name = "");
        IJobRoot Create<T>(Action<CancellationToken, T> action, T arg, Func<IRetryPolicy>? retryPolicyFactory = null, string name = "");
        IJobRoot Create<T>(Func<CancellationToken, T, Task> func, T arg, Func<IRetryPolicy>? retryPolicyFactory = null, string name = "");
        IJobRoot Create<T>(Guid id, Action<CancellationToken, T> body, T arg, Func<IRetryPolicy>? retryPolicyFactory = null, string name = "");
        IJobRoot Create<T>(Guid id, Func<CancellationToken, T, Task> body, T arg, Func<IRetryPolicy>? retryPolicyFactory = null, string name = "");
        IJobRoot Create<T1, T2>(Action<CancellationToken, T1, T2> action, T1 arg1, T2 arg2, Func<IRetryPolicy>? retryPolicyFactory = null, string name = "");
        IJobRoot Create<T1, T2>(Func<CancellationToken, T1, T2, Task> func, T1 arg1, T2 arg2, Func<IRetryPolicy>? retryPolicyFactory = null, string name = "");
        IJobRoot Create<T1, T2>(Guid id, Action<CancellationToken, T1, T2> body, T1 arg1, T2 arg2, Func<IRetryPolicy>? retryPolicyFactory = null, string name = "");
        IJobRoot Create<T1, T2>(Guid id, Func<CancellationToken, T1, T2, Task> body, T1 arg1, T2 arg2, Func<IRetryPolicy>? retryPolicyFactory = null, string name = "");
    }
}
