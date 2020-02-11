using System.Threading.Tasks;
using GetARide.Infrastructure.Commands.User;
using GetARide.Infrastructure.DTO;
using GetARide.Infrastructure.Services;
using GetARide.Infrastructure.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{email}")]
        public async Task<UserDto> Get(string email)
        {
          return  await _userService.GetUserAsync(email);
        }



        [HttpPost("")]
        public async Task Post([FromBody]CreateUser request)
        {
            await CommandDispatcher.DispatchAsync(request);
        }

    }
}