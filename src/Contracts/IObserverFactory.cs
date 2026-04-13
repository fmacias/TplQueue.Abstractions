using Microsoft.Extensions.Logging;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Factory for the observer components provided by the observer adapter package.
    /// </summary>
    public interface IObserverFactory
    {
        /// <summary>
        /// Creates the default inline observer dispatcher.
        /// </summary>
        IObserverDispatcher CreateObserverDispatcher();

        /// <summary>
        /// Creates an observer that writes job lifecycle events through <see cref="ILogger{TCategoryName}"/>.
        /// </summary>
        ILoggingObserver CreateLoggingObserver(ILogger<ILoggingObserver> logger);

        /// <summary>
        /// Creates an observer that writes job lifecycle events to the console.
        /// </summary>
        IConsoleObserver CreateConsoleObserver();

        /// <summary>
        /// Creates an observer that writes performance-oriented job lifecycle information through <see cref="ILogger{TCategoryName}"/>.
        /// </summary>
        IProfilingObserver CreateProfilingObserver(ILogger<IProfilingObserver> logger);

        /// <summary>
        /// Creates an observer that writes structured queue event lines through an application-provided logger.
        /// </summary>
        IFileLoggingObserver CreateFileLoggingObserver(ILogger logger, string queueName);
    }
}
