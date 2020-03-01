using System.Threading.Tasks;
using GetARide.Infrastructure.Commands.Driver;
using GetARide.Infrastructure.Commands.User;
using GetARide.Infrastructure.Services;

namespace GetARide.Infrastructure.Handlers.Drivers
{
    public class UpdateDriverHandler : ICommandHandler<UpdateDriver>
    {
        private readonly IDriverService _driverService;
        public UpdateDriverHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }
        public async Task HandleAsync(UpdateDriver command)
        {
            var vehicle = command.Vehicle;
            await _driverService.SetVehicle(command.UserId,vehicle.Brand,vehicle.Name);
        }
    }
}