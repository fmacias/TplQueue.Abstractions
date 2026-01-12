using System;

namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    /// <summary>
    /// Observer specialization for performance profiling of task runner events.
    /// </summary>
    public interface IProfilingObserver : IObserver<ITaskRunnerEvent>
    {
    }
}
