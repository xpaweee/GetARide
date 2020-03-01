using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GetARide.Core.Domain;
using GetARide.Core.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;


namespace GetARide.Infrastructure.Repositories
{
    public class UserMongoRepository : IUserRepository
    {
        private readonly IMongoDatabase _database;
        public UserMongoRepository(IMongoDatabase database)
        {
            _database = database;
        }
        public async Task<User> GetUserAsync(Guid id)
            => await Users.AsQueryable().FirstOrDefaultAsync( x=> x.Id == id);

        public async Task<User> GetUserAsync(string email)
            => await Users.AsQueryable().FirstOrDefaultAsync( x=> x.Email == email);
        public async Task AddAsync(User user)
              => await Users.InsertOneAsync(user);

        public async Task<IEnumerable<User>> BrowseAsync()
            => await Users.AsQueryable().ToListAsync();

        public async Task RemoveAsync(Guid id)
            => await Users.DeleteOneAsync(x => x.Id == id);

        public async Task UpdateAsync(User user)
            => await Users.ReplaceOneAsync(x => x.Id == user.Id,user);

        private IMongoCollection<User> Users => _database.GetCollection<User>("Users");
    }
}