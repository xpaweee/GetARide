using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GetARide.Core.Domain;

namespace GetARide.Core.Repositories
{
    public interface IUserRepository
    {
         Task<User> GetUserAsync(Guid id);
         Task<User> GetUserAsync(string email);
         Task AddAsync(User user);
         Task RemoveAsync(Guid id);
         Task UpdateAsync(User user);
         Task<IEnumerable<User>> GetAllAsync();
    }
}