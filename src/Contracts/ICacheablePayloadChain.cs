using System;
using System.Collections.Generic;
using System.Text;

namespace Fmacias.TplQueue.Contracts
{
    public interface ICacheablePayloadChain: IJobQ, IQueueablePayloadChain
    {
        int LeasingPulseMs { get; set; }
    }
}
