using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fmacias.TplQueue.Contracts
{
    public interface IUniversaDtoHandler
    {
        Func<object, CancellationToken, Task> ResolveAction { get; }
    }
}
