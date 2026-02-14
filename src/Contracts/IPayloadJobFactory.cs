using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Factory used to create and rehydrate payload-aware task runners.
    /// </summary>
    public interface IPayloadJobFactory
    {
        IPayloadJob<T> CreateJob<T>(
            T payload,
            string name = "") where T : IPayload;
        
        IPayloadJob<T> CreateJob<T>(
            Guid id,
            T payload,
            string name = "") where T : IPayload;

        IPayloadCarrierJob CreateJob(
            IJobNodeDto dto,
            IPayload payload);

        IPayloadJobRoot<T> CreateJobRoot<T>(
            T payload,
            string name = "") where T : IPayload;

        IPayloadJobRoot<T> CreateJobRoot<T>(
            T payload,
            Func<IRetryPolicy> policy,
            string name = "") where T : IPayload;

        IPayloadJobRoot<T> CreateJobRoot<T>(
            T payload,
            IRetryPolicyDescriptor retryPolicyDescriptor,
            string name = "") where T : IPayload;

        IPayloadJobRoot<T> CreateJobRoot<T>(
            Guid id,
            T payload,
            string name = "") where T : IPayload;

        IPayloadJobRoot<T> CreateJobRoot<T>(
            Guid id,
            T payload,
            IRetryPolicyDescriptor retryPolicyDescriptor,
            string name = "") where T : IPayload;

        IPayloadJobRoot CreateJobRoot(
            IJobNodeDto dto,
            IPayload payload);

        IPayloadJobRoot<T> CreateJobRoot<T>(
            Guid jobId,
            T payload,
            Func<IRetryPolicy> policy,
            string name = "") where T : IPayload;
    }
}
