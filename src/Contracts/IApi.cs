using System;
using System.Collections.Generic;

namespace Fmacias.TplQueue.Contracts
{
    public interface IApi
    {
        IRetryPolicyAbstractFactory RetryPolicyAbstractFactory { get; }
        IJobFactory JobFactory { get; }
        IDataJobFactory DataJobFactory { get; }
        IQFactoryAdapter QFactory { get; }
        IReadOnlyDictionary<string, IRetryPolicyOptions> RetryPolicyOptions { get; }
        IReadOnlyDictionary<string, IQOptions> QueueOptions { get; }
        T Cache<T>(ICacheFactory<T> cacheFactory, IUniversalDataSerializer serializer, ITypeResolver typeResolver)
            where T : IDataJobCache;
        T RetryPolicy<T>(IRetryPolicyFactory<T> retryPolicyFactory) 
            where T : IRetryPolicy;
        T RetryPolicy<T>(IRetryPolicyFactory<T> retryPolicyFactory, string name)
            where T : IRetryPolicy;
        T RetryPolicy<T>(IRetryPolicyFactory<T> retryPolicyFactory, IRetryPolicyOptions retryPolicyOptions)
            where T : IRetryPolicy;
        IExponentialBackoff RetryPolicy(IExponentialBackofFactory exponentialBackofFactory, int maxRetries, int delayMs, double factor);
        ILinearBackoff RetryPolicy(ILinearBackoffFactory linearBackofFactory, int maxRetries, int delayMs);
        ISystemTextJsonSerializerFactory SystemTexSerializerFactory();
        IObserverFactory ObserverFactory();
    }
}
 