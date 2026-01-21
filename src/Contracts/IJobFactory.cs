using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fmacias.TplQueue.Contracts
{
    public interface IJobFactory
    {
        IJob Create(Action<CancellationToken> body, string name = "");
        IJob Create(Func<CancellationToken, Task> body, string name = "");
        IJob Create(Guid id, Action<CancellationToken> body, string name = "");
        IJob Create(Guid id, Func<CancellationToken, Task> body, string name = "");
        IJob Create<T>(Action<CancellationToken, T> action, T arg, string name = "");
        IJob Create<T>(Func<CancellationToken, T, Task> func, T arg, string name = "");
        IJob Create<T>(Guid id, Action<CancellationToken, T> body, T arg, string name = "");
        IJob Create<T>(Guid id, Func<CancellationToken, T, Task> body, T arg, string name = "");
        IJob Create<T1, T2>(Action<CancellationToken, T1, T2> action, T1 arg1, T2 arg2, string name = "");
        IJob Create<T1, T2>(Func<CancellationToken, T1, T2, Task> func, T1 arg1, T2 arg2, string name = "");
        IJob Create<T1, T2>(Guid id, Action<CancellationToken, T1, T2> body, T1 arg1, T2 arg2, string name = "");
        IJob Create<T1, T2>(Guid id, Func<CancellationToken, T1, T2, Task> body, T1 arg1, T2 arg2, string name = "");
    }
}
