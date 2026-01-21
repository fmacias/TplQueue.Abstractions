using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Abstraction to dispatch observer callbacks on a UI or synchronization context,
    /// keeping observers testable and frontend-agnostic (WPF/WinUI/UWP/MAUI).
    ///
    /// Example (WPF):
    /// <code>
    /// using System.Windows.Threading;
    /// public class WpfDispatcher : IObserverDispatcher
    /// {
    ///     private readonly Dispatcher _dispatcher;
    ///     public WpfDispatcher(Dispatcher dispatcher)
    ///     {
    ///         _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
    ///     }
    ///     public void Invoke(Action action)
    ///     {
    ///         _dispatcher.Invoke(action);
    ///     }
    /// }
    /// </code>
    /// </summary>
    public interface IObserverDispatcher
    {
        /// <summary>
        /// Invokes the provided action on the dispatcher context.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        void Invoke(Action action);
    }
}
