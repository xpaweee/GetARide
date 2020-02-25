using System;
using System.Threading.Tasks;
using GetARide.Core.Domain;

namespace GetARide.Infrastructure.Services
{
    public class HandlerTask : IHandlerTask
    {

        private readonly IHandler _handler;
        private readonly Func<Task> _run;
        private  Func<Task> _validate;
        private  Func<Task> _always;
        private  Func<Task> _onSuccess;
        private  Func<Exception, Task> _onError;
        private  Func<GetARideException, Task> _onCustomError;

        private bool _propagateException = true;
        private bool _executeOnError = true;

        public HandlerTask(IHandler handler, Func<Task> run)
        {
            _handler = handler;
            _run = run;
        }
        public HandlerTask(IHandler handler, Func<Task> run, Func<Task> validate)
        {
            _handler = handler;
            _run = run;
            _validate = validate;
        }

        public IHandlerTask Always(Func<Task> always)
        {
            _always = always;

            return this;
        }

        public IHandlerTask DoNotPropagateException()
        {
           _propagateException = false;

           return this;
        }

   

        public IHandler Next()
             => _handler;

        public IHandlerTask OnCustomError(Func<GetARideException, Task> onCustomError, bool propagateException = false, bool executedOnError = false)
        {
            _onCustomError = onCustomError;
            _propagateException = propagateException;
            _executeOnError = executedOnError;

            return this;
        }

        public IHandlerTask OnError(Func<Exception, Task> onError, bool propagateException = false, bool executedOnError = false)
        {
            _onError = onError;
            _propagateException = propagateException;
            _executeOnError = executedOnError;

            return this;
        }

        public  IHandlerTask OnSucces(Func<Task> onSucces)
        {
            _onSuccess = onSucces;

            return this;
        }

        public IHandlerTask PropagateException()
        {
            _propagateException = true;

            return this;
        }

        public async Task ExecuteAsync()
        {
            try
            {
                if(_validate != null)
                    await _validate();

                await _run();

                if(_onSuccess != null)
                    await _onSuccess();
                
            }
            catch (Exception exception)
            {
                
               await HandlerExceptionAsyc(exception);
               if(_propagateException)
                throw;
            }
            finally
            {
                if(_always != null)
                    await _always();
            }
        }

        private async Task HandlerExceptionAsyc(Exception exception)
        {
            var customException = exception as GetARideException;
            if(customException is {})
            {
                if(_onCustomError is {})
                {
                    await _onCustomError(customException);
                }
            }
            var executeOnError = _executeOnError || customException == null;
            if(!executeOnError)
                return;

            if(_onError != null)
                await _onError(exception);
        }
    }
}