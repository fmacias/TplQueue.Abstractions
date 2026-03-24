using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fmacias.TplQueue.Contracts
{
    public interface IUniversalPayloadHandler
    {
        Func<object, CancellationToken, Task> ResolveAction { get; }
    }
}
