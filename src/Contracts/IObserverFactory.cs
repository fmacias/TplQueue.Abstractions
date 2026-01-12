using Microsoft.Extensions.Logging;

namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    public interface IObserverFactory
    {
        IObserverDispatcher CreateObserverDispatcher();
        ITaskQueueLoggingObserver CreateLoggingObserver(ILogger<ITaskQueueLoggingObserver> logger);
        ITaskRunnerConsoleObserver CreateConsoleObserver();
        IProfilingObserver CreateProfilingObserver(ILogger<IProfilingObserver> logger);
        ITaskRunnerViewModelObserver CreateViewModeObserver(IObserverDispatcher observerDispatcher);
    }
}
