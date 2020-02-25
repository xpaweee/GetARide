using System;
using System.Threading.Tasks;
using GetARide.Core.Domain;

namespace GetARide.Infrastructure.Services
{
    public interface IHandlerTask
    {
         IHandlerTask Always(Func<Task> always);
         IHandlerTask OnCustomError(Func<GetARideException,Task> onCustomError,bool propagateException = false,bool executedOnError = false);
         IHandlerTask OnError(Func<Exception,Task> onError,bool propagateException = false,bool executedOnError = false);
         IHandlerTask OnSucces(Func<Task> onSucces);
         IHandlerTask PropagateException();
         IHandlerTask DoNotPropagateException();
         IHandler Next();
         Task ExecuteAsync();
    }
}