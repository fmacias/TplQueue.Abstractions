using System;

namespace Fmacias.TplQueue.Contracts
{
    public interface IUniversalPayloadSerializer
    {
        string Serialize(object value, Type type);
        object Deserialize(string json, Type type);
        string Serialize<T>(T value);
        T Deserialize<T>(string json);
        string Serialize(IPayloadCarrierJob carrier);
    }
}
