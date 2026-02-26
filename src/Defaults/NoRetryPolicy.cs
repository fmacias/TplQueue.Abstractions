using Fmacias.TplQueue.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fmacias.TplQueue.Defaults
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

        public IRetryPolicyDescriptor ToDescriptor(Type retryPolicyType)
        {
            return RetryPolicyOptions.Create(0, 0, 0);
        }

        public IRetryPolicy SetFromDescriptor(IRetryPolicyDescriptor descriptor)
        {
            return Create();
        }
    }
}
