using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    public interface IRetryPolicy: IRetryPolicySerializable
    {
        /// <summary>
        /// Executes an asynchronous operation.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="action"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TResult> ExecuteAsync<TResult>(
            Func<CancellationToken, Task<TResult>> action,
            CancellationToken cancellationToken);
        int RetryCount { get; }
    }
}
