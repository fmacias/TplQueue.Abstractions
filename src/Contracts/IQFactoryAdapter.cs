using Microsoft.Extensions.Logging;

namespace Fmacias.TplQueue.Contracts
{
    public interface IQFactoryAdapter: IQFactoryCore
    {
        public IParallelQ CreateParallel(IQOptions queueOptions, string name, ILogger logger);
        public IParallelQ CreateParallel(string name, ILogger logger);
        public IFifoQ CreateFifo(IQOptions queueOptions, string name, ILogger logger);
        public IFifoQ CreateFifo(string name, ILogger logger);
        T GetCoreQ<T>(string name, ILogger<T> logger) where T : class, IJobQ;
    }
}
