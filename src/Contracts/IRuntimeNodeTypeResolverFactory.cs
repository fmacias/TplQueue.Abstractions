using System;

namespace Fmacias.TplQueue.Contracts
{
    public interface IRuntimeNodeTypeResolverFactory : INodeTypeResolverFactory<ITypeResolver>
    {
        IRuntimeNodeTypeResolver Resolver(AppDomain appDomain);
    }
}
