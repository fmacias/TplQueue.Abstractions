using System;
using System.Collections.Generic;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Non-generic carrier to allow heterogeneous queues to enforce “serializable-only”.
    /// </summary>
    public interface IPayloadCarrier: ITaskRunner
    {
        object GetPayload();
        Type PayloadType { get; }
        IReadOnlyList<IPayloadCarrier> GetPayloadDependencies();
    }

    public interface IPayloadCarrierRoot : IPayloadCarrier, ITaskRunnerRoot
    {
    }
    /// <summary>
    /// Nodo que porta un payload serializable. Es opcional:
    /// si un runner no lo implementa, se serializa solo la topología.
    /// </summary>
    public interface IPayloadCarrier<T> : IPayloadCarrier
    {
        T Payload { get; }
    }

    public interface IPayloadCarrierRoot<T> : IPayloadCarrierRoot
    {
    }

    /// <summary>
    /// Strongly-typed root payload task runner.
    /// Extends the payload-carrying root and the base runner root contract.
    /// </summary>
    public interface IPayloadTaskRunnerRoot<T> : IPayloadTaskRunner<T>, IPayloadCarrierRoot<T>, ITaskRunnerRoot
        where T : IPayloadCommand
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
    public interface IHandlerResolver
    {
        /// <summary>Debe devolver un handler UNTIPADO que acepte (object payload, CancellationToken ct).</summary>
        Func<object, System.Threading.CancellationToken, System.Threading.Tasks.Task> Resolve(Type payloadType);
    }
}
