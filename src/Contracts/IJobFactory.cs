using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fmacias.TplQueue.Contracts
{
    public interface IJobFactory
    {
        IJob CreateJob(Action<CancellationToken> body, string name = "");
        IJob CreateJob(Func<CancellationToken, Task> body, string name = "");
        IJob CreateJob(Guid id, Action<CancellationToken> body, string name = "");
        IJob CreateJob(Guid id, Func<CancellationToken, Task> body, string name = "");
        IJob CreateJob<T>(Action<CancellationToken, T> body, T arg, string name = "");
        IJob CreateJob<T>(Func<CancellationToken, T, Task> body, T arg, string name = "");
        IJob CreateJob<T>(Guid id, Action<CancellationToken, T> body, T arg, string name = "");
        IJob CreateJob<T>(Guid id, Func<CancellationToken, T, Task> body, T arg, string name = "");
        IJob CreateJob<T1, T2>(Action<CancellationToken, T1, T2> body, T1 arg1, T2 arg2, string name = "");
        IJob CreateJob<T1, T2>(Func<CancellationToken, T1, T2, Task> body, T1 arg1, T2 arg2, string name = "");
        IJob CreateJob<T1, T2>(Guid id, Action<CancellationToken, T1, T2> body, T1 arg1, T2 arg2, string name = "");
        IJob CreateJob<T1, T2>(Guid id, Func<CancellationToken, T1, T2, Task> body, T1 arg1, T2 arg2, string name = "");
    }
}
