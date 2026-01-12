using System;

namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    public interface ITaskQueueLoggingObserver : IObserver<ITaskRunnerEvent>
    {
    }
}
