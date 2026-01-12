using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    public interface IHandlerCatalog
    {
        Func<object?, CancellationToken, Task> Resolve(string handlerId);
    }
}
