using Fmacias.TplQueue.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fmacias.TplQueue
{
    public sealed class NoRetryPolicy : INoRetryPolicy
    {
        private NoRetryPolicy() { }
        public static NoRetryPolicy Create() => new();

        public int RetryCount => 0;

        public async Task<TResult> ExecuteAsync<TResult>(Func<CancellationToken, Task<TResult>> action, CancellationToken cancellationToken)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            cancellationToken.ThrowIfCancellationRequested();
            return await action(cancellationToken).ConfigureAwait(false);
        }

        public IRetryPolicyDescriptor ToDescriptor()
        {
            return RetryPolicyDescriptor.None;
        }

        public IRetryPolicy SetFromDescriptor(IRetryPolicyDescriptor descriptor)
        {
            return Create();
        }

        public IRetryPolicy SetFromOptions(RetryPolicyOptions options)
        {
            return Create();
        }
    }
}
