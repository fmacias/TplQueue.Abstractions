using System;
using System.Collections.Generic;
using System.Text;

namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    public interface ISerializationRunnerNodeAttributes
    {
        string HandlerId { get; set; }
        string? PayloadJson { get; set; }
        string? PayloadType { get; set; }
    }
}
