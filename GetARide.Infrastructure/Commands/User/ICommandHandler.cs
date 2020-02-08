using System.Threading.Tasks;

namespace GetARide.Infrastructure.Commands.User
{
    public interface ICommandHandler<T> where T:ICommand
    {
         Task HandleAsync(T command);
    }
}