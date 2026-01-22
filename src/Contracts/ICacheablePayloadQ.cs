using System;
using System.Collections.Generic;
using System.Text;

namespace Fmacias.TplQueue.Contracts
{
    public interface ICacheablePayloadQ: IJobQ, IQueueablePayloadQ
    {
        int LeasingPulseMs { get; set; }
    }
}
