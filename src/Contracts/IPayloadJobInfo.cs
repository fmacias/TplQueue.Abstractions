using System;
using System.Collections.Generic;
using System.Text;

namespace Fmacias.TplQueue.Contracts
{
    public interface IPayloadJobInfo<TPayload>:IJobInfo
    {
        TPayload Payload { get; }
    }
}
