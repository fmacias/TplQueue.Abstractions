using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Factory used to create and rehydrate payload-aware task runners.
    /// </summary>
    public interface IPayloadJobFactory
    {
        IPayloadJob<T> Create<T>(
            T payload,
            IUniversalPayloadSerializer serializer,
            string name = "")
            where T : IPayloadCommand;

        IPayloadJob<T> Create<T>(
            Guid JobId,
            T payload,
            IUniversalPayloadSerializer serializer,
            string name = "")
            where T : IPayloadCommand;

        /// <summary>
        /// Rehydrates a payload-carrying runner from a cache lease entry.
        /// </summary>
        IPayloadCarrierJob Load(
            ICacheLeaseEntry lease,
            IUniversalPayloadSerializer serializer);

        IPayloadJobRoot<T> CreateRoot<T>(
            Guid JobId,
            T payload,
            IUniversalPayloadSerializer serializer,
            Func<IRetryPolicy>? retryPolicyFactory = null,
            string name = "")
            where T : IPayloadCommand;

        IPayloadJobRoot<T> CreateRoot<T>(
            T payload,
            IUniversalPayloadSerializer serializer,
            Func<IRetryPolicy>? retryPolicyFactory = null,
            string name = "")
            where T : IPayloadCommand;

        /// <summary>
        /// Rehydrates a payload-carrying root runner from a cache lease entry.
        /// </summary>
        IPayloadJobRoot LoadRoot(
            ICacheLeaseEntry lease,
            IUniversalPayloadSerializer serializer);
    }
}
