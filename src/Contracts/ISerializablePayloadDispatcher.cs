using System;
using System.Collections.Generic;
using System.Text;

namespace Fmacias.TplQueue.Contracts
{
    public interface ISerializablePayloadDispatcher: ITaskDispatcher, ISerializablePayloadEnqueable
    {
        int LeasingPulseMs { get; set; }
    }
}
