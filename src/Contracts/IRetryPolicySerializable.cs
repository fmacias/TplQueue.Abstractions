using Fmacias.TplQueue;
using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Converts retry policies to/from a serializable descriptor.
    /// </summary>
    public interface IRetryPolicySerializable
    {
        /// <summary>Create a descriptor snapshot from a factory producing a policy instance.</summary>
        IRetryPolicyDescriptor ToDescriptor();
        IRetryPolicy SetFromDescriptor(IRetryPolicyDescriptor descriptor);
        IRetryPolicy SetFromOptions(RetryPolicyOptions options);
    }
}
