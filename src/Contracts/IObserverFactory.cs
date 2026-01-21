using Microsoft.Extensions.Logging;

namespace Fmacias.TplQueue.Contracts
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
