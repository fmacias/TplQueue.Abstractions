using System.Collections.Generic;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// <![CDATA[
    /// Factory responsible for creating concrete retry policy instances from:
    ///  - A logical name (resolved to RetryPolicyOptions),
    ///  - A RetryPolicyOptions value object,
    ///  - A serialized IRetryPolicyDescriptor (rehydration scenario),
    ///  - Or strongly-typed helper methods for the built-in policies.
    ///
    /// This interface lives in the Abstractions layer so that higher-level components
    /// can request retry policies without depending on concrete implementations.
    /// ]]>
    /// </summary>
    public interface IRetryPolicyFactory<TPolicy> where TPolicy : IRetryPolicy
    {
        TPolicy CreatePolicy();
        /// <summary>
        /// Create a retry policy by name from a configured options map.
        /// </summary>
        /// <param name="name">Logical policy name; must exist in the configured options dictionary.</param>
        /// <param name="options">Options dictionary</param>
        /// <returns></returns>
        TPolicy CreatePolicy(string name, IReadOnlyDictionary<string, IRetryPolicyDescriptor> options);
        TPolicy CreatePolicy(IRetryPolicyDescriptor descriptor);
    }
}
