using System;
using System.Collections.Generic;
using System.Text;

namespace Fmacias.TplQueue.Contracts
{
    public interface ISerializationJobNodeAttributes
    {
        string HandlerId { get; set; }
        string? PayloadJson { get; set; }
        string? PayloadType { get; set; }
    }
}
