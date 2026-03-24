using System;
using System.Collections.Generic;

namespace Fmacias.TplQueue.Contracts
{
    public interface IRetryPolicyAbstractFactory
    {
        IRetryPolicy PolicyByName(string name, IReadOnlyDictionary<string, IRetryPolicyOptions> options);
        T PolicyByName<T>(string name, IReadOnlyDictionary<string, IRetryPolicyOptions> options)
            where T : class, IRetryPolicy;
        IRetryPolicy PolicyByOptions(IRetryPolicyOptions options);
        T GetPolicy<T>() where T : class, IRetryPolicy;
    }
} 
