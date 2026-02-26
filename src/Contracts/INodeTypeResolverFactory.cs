namespace Fmacias.TplQueue.Contracts
{
    public interface INodeTypeResolverFactory<TNodeTypeResolver>
        where TNodeTypeResolver: INodeTypeResolver
    {
        TNodeTypeResolver CreateResolver();
    }
}
