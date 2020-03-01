using System.Threading.Tasks;
using GetARide.Infrastructure.Commands.Driver;
using GetARide.Infrastructure.Commands.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace GetARide.Api.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("drivers/routes")]
    public class DriverRoutesController : ApiControllerBase
    {
        public DriverRoutesController(ICommandDispatcher commandDispatcher) :base(commandDispatcher)
        {
            
        }
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Post([FromBody] CreateDriverRoute command)
        {
            await DispatchAsync(command);
            return NoContent();
        }
        
        [HttpDelete("{name}")]
        //[Authorize]
        public async Task<IActionResult> Post(string name)
        {
            var command = new DeleteDriverRoute
            {
                Name = name
            };
            await DispatchAsync(command);
            return NoContent();
        }
    }
}