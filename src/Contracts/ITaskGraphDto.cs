using System;
using System.Collections.Generic;

namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    public interface ITaskGraphDto
    {
        IReadOnlyList<ITaskRunnerNodeDto> ExtractNodes(Action<ITaskRunnerNodeDto, Guid> edgedNodeCallBack);
    }
}
