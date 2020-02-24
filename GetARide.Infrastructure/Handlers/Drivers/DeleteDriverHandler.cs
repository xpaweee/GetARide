using System.Threading.Tasks;
using GetARide.Infrastructure.Commands.Driver;
using GetARide.Infrastructure.Commands.User;
using GetARide.Infrastructure.Services;

namespace GetARide.Infrastructure.Handlers.Drivers
{
    public class DeleteDriverHandler : ICommandHandler<DeleteDriver>
    {
        private readonly IDriverService _driverService;
        public DeleteDriverHandler (IDriverService driverService) 
        {
            _driverService = driverService;
        }
        public async Task HandleAsync(DeleteDriver command)
        {
           await _driverService.DeleteAsync(command.UserId);
          
        }

    }
}