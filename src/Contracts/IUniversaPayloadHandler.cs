using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fmacias.TplQueue.Contracts
{
    public interface IUniversaPayloadHandler
    {
        Func<object, CancellationToken, Task> ResolveAction { get; }
    }
}
