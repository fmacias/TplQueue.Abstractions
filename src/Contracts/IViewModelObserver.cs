using System;

namespace Fmacias.TplQueue.Contracts
{
    public interface IViewModelObserver : IObserver<IJobEvent>
    {
    }
}
