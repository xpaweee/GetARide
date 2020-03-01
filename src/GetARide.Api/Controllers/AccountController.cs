using System;
using System.Threading.Tasks;
using GetARide.Infrastructure.Commands.User;
using GetARide.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GetARide.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ApiControllerBase
    {

        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        public AccountController(IUserService userService, ICommandDispatcher commandDispatcher, IJwtHandler jwtHandler) : base(commandDispatcher)
        {
            _userService = userService;
            _jwtHandler = jwtHandler;

        }

        [HttpGet]
        [Route("token")]
        public IActionResult GetToken()
        {
            var token = _jwtHandler.CreateToken(UserId,"user");
            return Json(token);
        }
        
        [HttpGet]
        [Authorize]
        [Route("auth")]
        public IActionResult GetAuth()
        {
            return Content("Auth");
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]ChangeUserPassword command)
        {
            await DispatchAsync(command);
            return NoContent();
        }
    }
}