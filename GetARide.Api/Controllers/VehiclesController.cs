using System.Threading.Tasks;
using GetARide.Infrastructure.Commands.User;
using GetARide.Infrastructure.Commands.Vehicle;
using Microsoft.AspNetCore.Mvc;

namespace GetARide.Api.Controllers
{
    [ApiController]
    [Route("controller")]
    public class VehiclesController : ApiControllerBase
    {
        public VehiclesController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {

        }


         [HttpPost("")]
         public async Task Post([FromBody]AddNewVehicle command)
         {
            await CommandDispatcher.DispatchAsync(command);
         }




        
    }
}