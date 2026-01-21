namespace Fmacias.TplQueue.Contracts
{
    public interface ISerializedPayload
    {
        string HandlerId { get; }
        string JsonInput { get; }
        string? JsonOutput { get; }
        string PayloadType { get; }
        ISerializedPayload SetOutput(string? payloadJson);
        ISerializedPayload SetInitialData(string? handlerId, string? jsonInput, string? payloadType); 
        bool IsSerializable();
    }
}
