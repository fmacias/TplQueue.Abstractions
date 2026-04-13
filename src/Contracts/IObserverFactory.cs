using Microsoft.Extensions.Logging;

namespace Fmacias.TplQueue.Contracts
{
    public interface IObserverFactory
    {
        IObserverDispatcher CreateObserverDispatcher();
        ILoggingObserver CreateLoggingObserver(ILogger<ILoggingObserver> logger);
        IConsoleObserver CreateConsoleObserver();
        IProfilingObserver CreateProfilingObserver(ILogger<IProfilingObserver> logger);
    }
}
