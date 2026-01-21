using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fmacias.TplQueue.Contracts
{
    public interface IHandlerCatalog
    {
        Func<object?, CancellationToken, Task> Resolve(string handlerId);
    }
}
