using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Observer specialization for queue event logging through an application-provided logger.
    /// </summary>
    public interface IFileLoggingObserver : IObserver<IJobEvent>
    {
    }
}
