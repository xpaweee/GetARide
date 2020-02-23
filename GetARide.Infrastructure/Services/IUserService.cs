using System.Collections.Generic;
using System.Threading.Tasks;
using GetARide.Infrastructure.DTO;

namespace GetARide.Infrastructure.Services
{
    public interface IUserService : IService
    {
         Task <UserDto> GetUserAsync(string email);
          Task<IEnumerable<UserDto>> BrowseAsync();
         Task RegisterAsync(string email,string username,string password);
         Task LoginAsync(string email, string password);
    }
}