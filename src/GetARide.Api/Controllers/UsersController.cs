using System.Threading.Tasks;
using GetARide.Infrastructure.Commands.User;
using GetARide.Infrastructure.DTO;
using GetARide.Infrastructure.Services;
using GetARide.Infrastructure.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GetARide.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ApiControllerBase
    {

        private readonly IUserService _userService;
        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher, GeneralSettings settings) : base(commandDispatcher)
        {
            _userService = userService;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.BrowseAsync();
            return Json(users);
        }

        // [Authorize]
        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
            => Json(await _userService.GetUserAsync(email));



        [HttpPost("")]
        public async Task Post([FromBody]CreateUser request)
        {
            await DispatchAsync(request);
        }


        // [HttpPost("")]
        // public async Task Post([FromBody]CreateUser request)
        // {
        //     await _userService.RegisterAsync(request.Email,request.Username,request.Password);
        // }

    }
}