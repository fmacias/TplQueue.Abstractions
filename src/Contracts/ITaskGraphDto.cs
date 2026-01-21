using System;
using System.Collections.Generic;

namespace Fmacias.TplQueue.Contracts
{
    public interface ITaskGraphDto
    {
        IReadOnlyList<ITaskRunnerNodeDto> ExtractNodes(Action<ITaskRunnerNodeDto, Guid> edgedNodeCallBack);
    }
}
