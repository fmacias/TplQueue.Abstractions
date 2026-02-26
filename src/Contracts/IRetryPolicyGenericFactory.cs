using System.Collections.Generic;

namespace Fmacias.TplQueue.Contracts
{
    public interface IRetryPolicyGenericFactory
    {
        IRetryPolicy PolicyByName(string name, IReadOnlyDictionary<string, IRetryPolicyDescriptor> options);
        T PolicyByName<T>(string name, IReadOnlyDictionary<string, IRetryPolicyDescriptor> options)
            where T : class, IRetryPolicy;
        IRetryPolicy PolicyByDescriptor(IRetryPolicyDescriptor descriptor);
        bool TryGetPolicy<T>(out T policy) where T : class, IRetryPolicy;
        T GetPolicy<T>() where T : class, IRetryPolicy;
    }
}
