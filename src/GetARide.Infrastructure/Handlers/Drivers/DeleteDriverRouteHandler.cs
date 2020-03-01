using System;
using System.Threading.Tasks;
using GetARide.Infrastructure.Commands.Driver;
using GetARide.Infrastructure.Commands.User;
using GetARide.Infrastructure.Services;

namespace GetARide.Infrastructure.Handlers.Drivers
{
    public class DeleteDriverRouteHandler : ICommandHandler<DeleteDriverRoute>
    {
        public readonly IDriverService _driverService;
        public DeleteDriverRouteHandler (IDriverService driverService) {
            _driverService = driverService;
        }
        public async Task HandleAsync(DeleteDriverRoute command)
        {
            throw new NotImplementedException();
          
        }
    }
}