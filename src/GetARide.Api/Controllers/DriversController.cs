using System;
using System.Threading.Tasks;
using GetARide.Infrastructure.Commands.Driver;
using GetARide.Infrastructure.Commands.User;
using GetARide.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace GetARide.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriversController : ApiControllerBase
    {
        private readonly IDriverService _driverService;
        public DriversController(ICommandDispatcher commandDispatcher, IDriverService driverService) : base(commandDispatcher)
        {
            _driverService = driverService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //throw new Exception("ups");
            var drivers = await _driverService.BrowseAsync();

            return Json(drivers);
        }
        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> Get(Guid userId)
        {
            var driver = await _driverService.Get(userId);
            if(driver is null)
                return NotFound();

            return Json(driver);
        }

        [HttpDelete("me")]
        public async Task<IActionResult> Post()
        {
            await DispatchAsync(new DeleteDriver());
            return NoContent();
        }

        [HttpPut("me")]
        public async Task<IActionResult> Put([FromBody] UpdateDriver command)
        {
            await DispatchAsync(command);
            return NoContent();
        }
    }
}