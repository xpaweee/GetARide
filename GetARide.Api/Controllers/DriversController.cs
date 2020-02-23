using System.Threading.Tasks;
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
            var drivers = await _driverService.BrowseAsync();

            return Json(drivers);
        }
    }
}