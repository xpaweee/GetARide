using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetARide.Core.Domain;
using GetARide.Core.Repositories;

namespace GetARide.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository, IMongoRepository 
    {
        private static ISet<User> _users = new HashSet<User>
        {
            new User(Guid.NewGuid(),"test","testowy","admin","password","salt"),
            new User(Guid.NewGuid(),"User2@gmail.com","admin","testowy2","password2","salt2"),
            new User(Guid.NewGuid(),"User3@gmail.com","admin","testowy3","password3","salt3")
        };

        public async Task AddAsync(User user)
            => await Task.FromResult(_users.Add(user));

        public  async Task<IEnumerable<User>> BrowseAsync()
            =>  await Task.FromResult(_users);

        public async Task<User> GetUserAsync(Guid id)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Id == id));

        public async Task<User> GetUserAsync(string email)
             => await Task.FromResult(_users.SingleOrDefault(x => x.Email == email));

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetUserAsync(id);
            _users.Remove(user);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }
    }
}