using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fmacias.TplQueue.Contracts
{
    public interface IJobFactory: IJobRootFactory
    {
        IJob Job(Action<CancellationToken> body, string name = "");
        IJob Job(Func<CancellationToken, Task> body, string name = "");
        IJob Job(Guid id, Action<CancellationToken> body, string name = "");
        IJob Job(Guid id, Func<CancellationToken, Task> body, string name = "");
        IJob Job<T>(Action<CancellationToken, T> body, T arg, string name = "");
        IJob Job<T>(Func<CancellationToken, T, Task> body, T arg, string name = "");
        IJob Job<T>(Guid id, Action<CancellationToken, T> body, T arg, string name = "");
        IJob Job<T>(Guid id, Func<CancellationToken, T, Task> body, T arg, string name = "");
        IJob Job<T1, T2>(Action<CancellationToken, T1, T2> body, T1 arg1, T2 arg2, string name = "");
        IJob Job<T1, T2>(Func<CancellationToken, T1, T2, Task> body, T1 arg1, T2 arg2, string name = "");
        IJob Job<T1, T2>(Guid id, Action<CancellationToken, T1, T2> body, T1 arg1, T2 arg2, string name = "");
        IJob Job<T1, T2>(Guid id, Func<CancellationToken, T1, T2, Task> body, T1 arg1, T2 arg2, string name = "");
    }
}
