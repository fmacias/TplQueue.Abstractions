namespace Fmacias.TplQueue.Contracts
{
    public interface INodeTypeResolverFactory<TNodeTypeResolver>
        where TNodeTypeResolver: ITypeResolver
    {
        TNodeTypeResolver Resolver();
    }
}
