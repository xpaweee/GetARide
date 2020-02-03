using GetARide.Infrastructure.DTO;
using GetARide.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace GetARide.Api.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class UsersController {


        private readonly IUserService _userService;
        public UsersController (IUserService userService) {
            _userService = userService;
            

        }

        [HttpGet("{email}")]
        public UserDto Get(string email)
            => _userService.GetUser(email);

    }
}