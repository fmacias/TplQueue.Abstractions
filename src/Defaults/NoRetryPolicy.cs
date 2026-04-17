using Fmacias.TplQueue.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fmacias.TplQueue.Defaults
{
    /// <summary>
    /// Default retry policy that executes an operation once and performs no retry attempts.
    /// </summary>
    /// <remarks>
    /// This type is allowed in <c>Fmacias.TplQueue.Defaults</c> because it is stateless:
    /// it does not mutate global state, does not store shared runtime data, and only provides
    /// a minimal default implementation for callers that need an <see cref="IRetryPolicy"/>
    /// outside an API composition context.
    /// </remarks>
    public sealed class NoRetryPolicy : INoRetryPolicy
    {
        /// <summary>
        /// Initializes a retry policy that executes the operation once without retrying.
        /// </summary>
        public NoRetryPolicy() { }

        /// <summary>
        /// Creates a retry policy that executes the operation once without retrying.
        /// </summary>
        public static NoRetryPolicy Create() => new();

        /// <inheritdoc />
        public int RetryCount => 0;

        /// <inheritdoc />
        public async Task<TResult> ExecuteAsync<TResult>(Func<CancellationToken, Task<TResult>> action, CancellationToken cancellationToken)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            cancellationToken.ThrowIfCancellationRequested();
            return await action(cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IRetryPolicyOptions ToDescriptor()
        {
            return RetryPolicyOptions.Create(0, 0, 0);
        }

        /// <inheritdoc />
        public IRetryPolicy SetFromDescriptor(IRetryPolicyOptions descriptor)
        {
            return Create();
        }
    }
}
