using System;
using System.Collections.Generic;
using System.Linq;
using GetARide.Core.Domain;
using GetARide.Core.Repositories;

namespace GetARide.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>
        {
            new User("test","testowy","password","salt"),
            new User("User2@gmail.com","testowy2","password2","salt2"),
            new User("User3@gmail.com","testowy3","password3","salt3")
        };

        public void Add(User user)
        {
            _users.Add(user);
        }

        public IEnumerable<User> GetAll()
            => _users;

        public User GetUser(Guid id)
            => _users.Single(x => x.Id == id);
        

        public User GetUser(string email)
            => _users.SingleOrDefault(x => x.Email.ToLowerInvariant() == email.ToLowerInvariant());
       
        public void Remove(Guid id)
        {
            var user = GetUser(id);
            _users.Remove(user);
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}