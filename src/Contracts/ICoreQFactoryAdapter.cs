using Microsoft.Extensions.Logging;

namespace Fmacias.TplQueue.Contracts
{
    public interface ICoreQFactoryAdapter: ICoreQFactory
    {
        public IParallelQ Parallel(IQOptions queueOptions, string name, ILogger logger);
        public IParallelQ Parallel(string name, ILogger logger);
        public IFifoQ Fifo(IQOptions queueOptions, string name, ILogger logger);
        public IFifoQ Fifo(string name, ILogger logger);
        T GetCoreQ<T>(string name, ILogger<T> logger) where T : class, IQ;
    }
}
