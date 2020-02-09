using System.Threading.Tasks;

namespace GetARide.Infrastructure.Commands.User
{
    public interface ICommandDispatcher
    {
         Task DispatchAsync<T>(T command) where T: ICommand;
    }
}