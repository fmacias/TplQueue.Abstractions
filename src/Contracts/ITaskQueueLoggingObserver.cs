using System;

namespace Fmacias.TplQueue.Contracts
{
    public interface ITaskQueueLoggingObserver : IObserver<ITaskRunnerEvent>
    {
    }
}
