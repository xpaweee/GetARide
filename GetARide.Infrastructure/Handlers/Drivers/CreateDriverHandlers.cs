using System.Threading.Tasks;
using GetARide.Infrastructure.Commands;
using GetARide.Infrastructure.Commands.User;
using GetARide.Infrastructure.Services;

namespace GetARide.Infrastructure.Handlers.Drivers {
    public class CreateDriverHandlers : ICommandHandler<CreateDriver> {
        public readonly IDriverService _driverService;
        public CreateDriverHandlers (IDriverService driverService) {
            _driverService = driverService;
        }

        public Task HandleAsync(CreateDriver command)
        {
            throw new System.NotImplementedException();
        }
    }
}