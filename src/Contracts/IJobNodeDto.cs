using System;

namespace Fmacias.TplQueue.Contracts
{
    public interface IJobNodeDto: IJobNodeRecord
    {
        Type PayloadType { get; }
    }
}
