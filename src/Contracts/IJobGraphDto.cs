using System;
using System.Collections.Generic;

namespace Fmacias.TplQueue.Contracts
{
    public interface IJobGraphDto
    {
        IReadOnlyList<IJobNodeDto> ExtractNodes(Action<IJobNodeRecord, Guid> edgedNodeCallBack);
    }
}
