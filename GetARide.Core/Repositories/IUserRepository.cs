using System;
using System.Collections.Generic;
using GetARide.Core.Domain;

namespace GetARide.Core.Repositories
{
    public interface IUserRepository
    {
         User GetUser(Guid id);
         User GetUser(string email);
         void Add(User user);
         void Remove(Guid id);
         void Update(User user);
         IEnumerable<User> GetAll();
    }
}