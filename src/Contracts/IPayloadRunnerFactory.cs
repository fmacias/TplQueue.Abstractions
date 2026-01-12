using System;

namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    /// <summary>
    /// Factory used to create and rehydrate payload-aware task runners.
    /// </summary>
    public interface IPayloadRunnerFactory
    {
        IPayloadTaskRunner<T> Create<T>(
            T payload,
            IUniversalPayloadSerializer serializer,
            string name = "")
            where T : IPayloadCommand;

        IPayloadTaskRunner<T> Create<T>(
            Guid taskRunnerId,
            T payload,
            IUniversalPayloadSerializer serializer,
            string name = "")
            where T : IPayloadCommand;

        /// <summary>
        /// Rehydrates a payload-carrying runner from a cache lease entry.
        /// </summary>
        IPayloadCarrier Load(
            ICacheLeaseEntry lease,
            IUniversalPayloadSerializer serializer);

        IPayloadTaskRunnerRoot<T> CreateRoot<T>(
            Guid taskRunnerId,
            T payload,
            IUniversalPayloadSerializer serializer,
            Func<IRetryPolicy>? retryPolicyFactory = null,
            string name = "")
            where T : IPayloadCommand;

        IPayloadTaskRunnerRoot<T> CreateRoot<T>(
            T payload,
            IUniversalPayloadSerializer serializer,
            Func<IRetryPolicy>? retryPolicyFactory = null,
            string name = "")
            where T : IPayloadCommand;

        /// <summary>
        /// Rehydrates a payload-carrying root runner from a cache lease entry.
        /// </summary>
        IPayloadCarrierRoot LoadRoot(
            ICacheLeaseEntry lease,
            IUniversalPayloadSerializer serializer);
    }
}
