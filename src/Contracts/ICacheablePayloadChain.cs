using System;
using System.Collections.Generic;
using System.Text;

namespace Fmacias.TplQueue.Contracts
{
    public interface ICacheablePayloadChain: IJobsChain, IQueueablePayloadChain
    {
        int LeasingPulseMs { get; set; }
    }
}
