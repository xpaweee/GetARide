using System.Threading.Tasks;
using GetARide.Infrastructure.Commands.Driver;
using GetARide.Infrastructure.Commands.User;
using GetARide.Infrastructure.Services;

namespace GetARide.Infrastructure.Handlers.Drivers
{
    public class CreateDriverRouteHandler : ICommandHandler<CreateDriverRoute>
    {
        private readonly IDriverRouteService _driverRouteService;
        public CreateDriverRouteHandler(IDriverRouteService driverRouteService)
        {
            _driverRouteService = driverRouteService;
        }
        public async Task HandleAsync(CreateDriverRoute command)
        {
            await _driverRouteService.AddAsync(command.UserId,command.Name,
            command.StartLatitude,command.EndLatitude,command.StartLongtitude,command.EndLongtitude);
            
        }
    }
}