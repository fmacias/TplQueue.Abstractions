using System;

namespace Fmacias.TplQueue.Contracts
{
    public interface IUniversalPayloadSerializer
    {
        // Dynamic (existing)
        string Serialize(object value, Type type);
        object Deserialize(string json, Type type);

        // Fast, strongly-typed (new)
        string Serialize<T>(T value) where T : IPayloadCommand;
        T Deserialize<T>(string json) where T : IPayloadCommand;
        string Serialize(IPayloadCarrierJob carrier);
    }
}
