using System.Text.Json;

namespace Fmacias.TplQueue.Contracts
{
    public interface ISystemTextJsonSerializerFactory: IJsonSerializerFactory
    {
        ISystemTextJsonUniversalSerializer CreateSerializer(JsonSerializerOptions options);
    }
}
