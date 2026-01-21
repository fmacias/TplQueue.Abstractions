using System;
using System.Collections.Generic;

namespace Fmacias.TplQueue.Contracts
{
    public interface ITaskGraphDto
    {
        IReadOnlyList<IJobNodeDto> ExtractNodes(Action<IJobNodeDto, Guid> edgedNodeCallBack);
    }
}
