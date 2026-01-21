using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Observer specialization for performance profiling of task runner events.
    /// </summary>
    public interface IProfilingObserver : IObserver<IJobEvent>
    {
    }
}
