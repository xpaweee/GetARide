using System.Threading.Tasks;
using GetARide.Infrastructure.Commands.User;
using GetARide.Infrastructure.Commands.Vehicle;
using GetARide.Infrastructure.Services;

namespace GetARide.Infrastructure.Handlers.Vehicles {
    public class AddNewVehicleHandler : ICommandHandler<AddNewVehicle> 
    {
        private readonly IVehicleService _vehicleService; 
        public AddNewVehicleHandler (IVehicleService vehicleService) {
            _vehicleService = vehicleService;
        }

        public async Task HandleAsync (AddNewVehicle command) {
            await _vehicleService.CreateAsync(command.Name,command.Seats);
        }
    }
}