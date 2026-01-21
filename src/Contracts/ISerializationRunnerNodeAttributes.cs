using System;
using System.Collections.Generic;
using System.Text;

namespace Fmacias.TplQueue.Contracts
{
    public interface ISerializationRunnerNodeAttributes
    {
        string HandlerId { get; set; }
        string? PayloadJson { get; set; }
        string? PayloadType { get; set; }
    }
}
