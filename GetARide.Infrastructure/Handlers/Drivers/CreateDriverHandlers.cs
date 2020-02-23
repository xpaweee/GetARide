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

        public async Task HandleAsync(CreateDriver command)
        {
            await _driverService.CreateAsync(command.UserId);
            var vehicle = command.Vehicle;
            await _driverService.SetVehicle(command.UserId,vehicle.Brand,vehicle.Name,vehicle.Seats);
        }
    }
}