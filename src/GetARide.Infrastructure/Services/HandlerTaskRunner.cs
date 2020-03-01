using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetARide.Infrastructure.Services
{
    public class HandlerTaskRunner : IHandlerTaskRunner
    {
        private readonly IHandler _handler;
        private readonly Func<Task> _validate;
        private readonly ISet<IHandlerTask> _handlerTask;

        public HandlerTaskRunner(IHandler handler,Func<Task> validate ,ISet<IHandlerTask> handlerTask )
        {
            _handler = handler;
            _validate = validate;
            _handlerTask = handlerTask;
        }
        public IHandlerTask Run(Func<Task> run)
        {
            var handlerTask = new HandlerTask(_handler,run);
            _handlerTask.Add(handlerTask);

            return handlerTask;
        }
    }
}