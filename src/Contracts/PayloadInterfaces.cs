using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Non-generic carrier to allow heterogeneous queues to enforce “serializable-only”.
    /// </summary>
    public interface IPayloadCarrierJob: IJob, IPayloadJobInfo
    {
        object GetPayload();
        Type PayloadType { get; }
        IReadOnlyList<IPayloadCarrierJob> GetPayloadDependencies();
    }

    public interface IPayloadJobRoot : IPayloadCarrierJob, IJobRoot
    {
    }
    /// <summary>
    /// Nodo que porta un payload serializable. Es opcional:
    /// si un runner no lo implementa, se serializa solo la topología.
    /// </summary>
    public interface IPayloadCarrier<T> : IPayloadCarrierJob
    {
        T Payload { get; }
    }

    public interface IPayloadCarrierRoot<T> : IPayloadJobRoot
    {
    }

    /// <summary>
    /// Strongly-typed root payload task runner.
    /// Extends the payload-carrying root and the base runner root contract.
    /// </summary>
    public interface IPayloadJobRoot<T> : IPayloadJob<T>, IPayloadCarrierRoot<T>, IJobRoot
        where T : IPayload
    {
    }
    
    public interface IJsonPayloadSerializer<T> : IPayloadSerializer<T>
    {

    }
    public interface IPayloadSerializer<T>
    {
        string Serialize(T value);
        T Deserialize(string data);
    }
    /// <summary>
    /// Resuelve el handler (Func&lt;payload, CancellationToken, Task&gt;) para un tipo de payload.
    /// </summary>
    [Obsolete("Use IJobHandlerResolver instead.")]
    public interface IHandlerResolver
    {
        /// <summary>Debe devolver un handler UNTIPADO que acepte (object payload, CancellationToken ct).</summary>
        Func<object, CancellationToken, Task> Resolve(Type payloadType);
    }
}
