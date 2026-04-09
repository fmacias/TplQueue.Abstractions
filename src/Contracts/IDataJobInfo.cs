namespace Fmacias.TplQueue.Contracts
{
    public interface IDataJobInfo : IJobInfo, ISerializable
    {
        /// <summary>
        /// Stable payload handler key persisted with dehydrated payload jobs.
        /// </summary>
        string PayloadHandlerKey { get; }
    }
}
