using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Controls a background dispatcher that polls and executes enqueued <see cref="IJob"/> items
    /// and publishes lifecycle events via <see cref="IObservable{T}"/>.
    /// </summary>
    public interface IJobQ : IObservable<IJobEvent>, IDisposable
    {
        /// <summary>
        /// Starts polling for work using the configured cadence and parallelism.
        /// Safe to call multiple times; subsequent calls are no-ops if already running.
        /// </summary>
        void Start();

        /// <summary>
        /// Requests the dispatcher to stop polling and finish outstanding callbacks gracefully.
        /// Safe to call multiple times; subsequent calls are no-ops if already stopped.
        /// </summary>
        void Pause();

        /// <summary>
        /// True once <see cref="IDisposable.Dispose"/> has been called.
        /// </summary>
        bool IsDisposed { get; }

        /// <summary>
        /// Optional async delegator invoked for each internal queue event.
        /// Must be non-blocking and resilient to exceptions. The dispatcher will
        /// catch and ignore any exception thrown by the delegator to preserve stability.
        /// </summary>
        /// <remarks>
        /// Keep this fast and allocation-free. Implementations should capture a local copy
        /// before invocation to avoid races with concurrent setters.
        /// </remarks>
        Func<IJobEvent, Task> OnJobEventChanged { get; set; }
        IJobQ Enqueue(IJobRoot jobRoot, bool isFifo, CancellationToken cancellationToken);
        IJobQ Enqueue(IJobRoot jobRoot, CancellationToken ct);
        IJobQ EnqueueFifo(IJobRoot jobRoot, CancellationToken ct);

        string Name { get; }
        int MaxParallelism { get; }
        Func<IRetryPolicy> RetryPolicyFactory { get; }
        SemaphoreSlim Semaphore { get; }
        Task Wait(int stateAtMs = 0);
        IJobQ SetRetryPolicyFactory(Func<IRetryPolicy> retryPolicy);
    }
}
