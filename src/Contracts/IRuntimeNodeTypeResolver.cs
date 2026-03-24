using System;

namespace Fmacias.TplQueue.Contracts
{
    public interface IRuntimeNodeTypeResolver:ITypeResolver
    {
        AppDomain AppDomain { get; }
    }
}
