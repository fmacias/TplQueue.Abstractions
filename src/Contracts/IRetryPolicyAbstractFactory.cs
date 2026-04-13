using System;
using System.Collections.Generic;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Creates retry policies from registered names, retry policy options, or a requested retry policy type.
    /// </summary>
    /// <remarks>
    /// The built-in retry policy interfaces <see cref="INoRetryPolicy"/>, <see cref="ILinearBackoff"/>,
    /// and <see cref="IExponentialBackoff"/> are supported directly by the default adapter implementation.
    /// Custom policies should be requested by concrete type and must expose a public parameterless constructor.
    /// </remarks>
    public interface IRetryPolicyAbstractFactory
    {
        /// <summary>
        /// Resolves a retry policy by name from the provided options map.
        /// </summary>
        /// <param name="name">The configured retry policy name.</param>
        /// <param name="options">The available retry policy options keyed by name.</param>
        /// <returns>
        /// The retry policy created from the matched options, or the factory's default no-retry policy
        /// when the name is not registered.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is null, empty, or whitespace.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="options"/> is null.</exception>
        IRetryPolicy PolicyByName(string name, IReadOnlyDictionary<string, IRetryPolicyOptions> options);

        /// <summary>
        /// Resolves a named retry policy and returns it as the requested retry policy type.
        /// </summary>
        /// <typeparam name="T">
        /// The requested retry policy type. Built-in retry policy interfaces are supported. Custom
        /// policies should use a concrete type with a public parameterless constructor.
        /// </typeparam>
        /// <param name="name">The configured retry policy name.</param>
        /// <param name="options">The available retry policy options keyed by name.</param>
        /// <returns>The retry policy created from the matched options and assignable to <typeparamref name="T"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is null, empty, or whitespace.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="options"/> is null.</exception>
        /// <exception cref="KeyNotFoundException">Thrown when <paramref name="name"/> is not registered.</exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when a created policy cannot be returned as <typeparamref name="T"/>.
        /// </exception>
        T PolicyByName<T>(string name, IReadOnlyDictionary<string, IRetryPolicyOptions> options)
            where T : class, IRetryPolicy;

        /// <summary>
        /// Creates a retry policy directly from retry policy options.
        /// </summary>
        /// <param name="options">The retry policy options used to choose and configure the policy.</param>
        /// <returns>The retry policy created from <paramref name="options"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="options"/> is null.</exception>
        IRetryPolicy PolicyByOptions(IRetryPolicyOptions options);

        /// <summary>
        /// Creates the default instance for the requested retry policy type.
        /// </summary>
        /// <typeparam name="T">
        /// The requested retry policy type. Built-in retry policy interfaces are supported. Custom
        /// policies should use a concrete type with a public parameterless constructor.
        /// </typeparam>
        /// <returns>The default retry policy instance assignable to <typeparamref name="T"/>.</returns>
        T GetPolicy<T>() where T : class, IRetryPolicy;
    }
} 
