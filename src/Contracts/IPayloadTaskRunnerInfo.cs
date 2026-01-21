using System;
using System.Collections.Generic;
using System.Text;

namespace Fmacias.TplQueue.Contracts
{
    public interface IPayloadTaskRunnerInfo<TPayload>:ITaskRunnerInfo
    {
        TPayload Payload { get; }
    }
}
