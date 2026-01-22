using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fmacias.TplQueue.Contracts
{
    public interface IStrictFifoEnqueueable
    {
        IJobQ Enqueue(Action<CancellationToken> action, CancellationToken ct, string name = "");
        IJobQ Enqueue(Func<CancellationToken, Task> func, CancellationToken ct, string name = "");
        IJobQ Enqueue<T>(Action<CancellationToken, T> action, T arg, CancellationToken ct, string name = "");
        IJobQ Enqueue<T>(Func<CancellationToken, T, Task> func, T arg, CancellationToken ct, string name = "");
        IJobQ Enqueue<T1, T2>(Action<CancellationToken, T1, T2> action, T1 arg1, T2 arg2, CancellationToken ct, string name = "");
        IJobQ Enqueue<T1, T2>(Func<CancellationToken, T1, T2, Task> func, T1 arg1, T2 arg2, CancellationToken ct, string name = "");
    }
}
