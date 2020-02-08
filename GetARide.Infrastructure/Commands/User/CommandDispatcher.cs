using System;
using System.Threading.Tasks;
using Autofac;

namespace GetARide.Infrastructure.Commands.User
{
    public class CommandDispatcher : ICommandDispatcher
    {
        public IComponentContext _context { get; }
        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if(command is null)
                throw new ArgumentNullException(nameof(command),"Command can not be null.");
            
            var handler = _context.Resolve<ICommandHandler<T>>();
            await handler.HandleAsync(command);

        }
    }
}