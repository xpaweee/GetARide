using GetARide.Infrastructure.DTO;

namespace GetARide.Infrastructure.Services
{
    public interface IUserService
    {
        UserDto GetUser(string email);
         void Register(string email,string username,string password);
    }
}