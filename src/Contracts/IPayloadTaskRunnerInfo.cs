using System;
using System.Collections.Generic;
using System.Text;

namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    public interface IPayloadTaskRunnerInfo<TPayload>:ITaskRunnerInfo
    {
        TPayload Payload { get; }
    }
}
