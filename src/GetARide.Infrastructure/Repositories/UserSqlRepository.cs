using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GetARide.Core.Domain;
using GetARide.Core.Repositories;
using GetARide.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace GetARide.Infrastructure.Repositories
{
    public class UserSqlRepository : IUserRepository, ISqlRepository
    {
        private readonly GetARideContext _context;
        public UserSqlRepository(GetARideContext context)
        {
            _context = context;
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> BrowseAsync()
            => await _context.Users.ToListAsync();

        public async Task<User> GetUserAsync(Guid id)
            => await _context.Users.SingleOrDefaultAsync( x => x.Id == id);

        public async Task<User> GetUserAsync(string email)
            => await _context.Users.SingleOrDefaultAsync( x => x.Email == email);

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetUserAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}