using System.Threading.Tasks;
using GetARide.Infrastructure.Commands.User;
using GetARide.Infrastructure.DTO;
using GetARide.Infrastructure.Extensions;
using GetARide.Infrastructure.Services;
using Microsoft.Extensions.Caching.Memory;

namespace GetARide.Infrastructure.Handlers.Users
{
    public class LoginHandler : ICommandHandler<Login>
    {
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _cache;
        private readonly IHandler _handler;

        public LoginHandler(IHandler handler,IUserService userService, IJwtHandler jwtHandler, IMemoryCache cache)
        {
            _handler = handler;
            _userService = userService;
            _jwtHandler = jwtHandler;
            _cache = cache;
        }
        public async Task HandleAsync(Login command)
            => await _handler
            .Run(async () => await _userService.LoginAsync(command.Email,command.Password))
            .Next()
            .Run(async () => 
            {
                var user = await _userService.GetUserAsync(command.Email);
                var jwt = _jwtHandler.CreateToken(user.Id,user.Role);
                _cache.SetJwt(command.TokenId,jwt);
            })
            .ExecuteAsync();

            
        // public async Task HandleAsync(Login command)
        // {
        //     await _userService.LoginAsync(command.Email,command.Password);
        //     var user = await _userService.GetUserAsync(command.Email);
        //     var jwt = _jwtHandler.CreateToken(user.Id,user.Role);
        //     _cache.SetJwt(command.TokenId,jwt);
        // }
    }
}