using System;

namespace Fmacias.TplQueue.Contracts
{
    public interface ILoggingObserver : IObserver<IJobEvent>
    {
    }
}
