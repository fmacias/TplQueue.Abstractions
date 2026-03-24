using System;

namespace Fmacias.TplQueue.Contracts
{
    public interface IDataJobInfo:IJobInfo, ISerializable
    {
        Guid PayloadHandlerId { get; }
    }
}
