using System;
using System.Threading.Tasks;
using GetARide.Core.Domain;
using GetARide.Core.Repositories;

namespace GetARide.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static async Task<Driver> GetOrFailAsync(this IDriverRepository repository,Guid userId)
        {
           var driver = await repository.Get(userId);
            if(driver is null )
                throw new Exception($"Driver with id: {userId} was not found");
            return driver;
        }
        public static async Task<User> GetOrFailAsync(this IUserRepository repository,Guid userId)
        {
           var user = await repository.GetUserAsync(userId);
            if(user is null )
                throw new Exception($"Driver with id: {user} was not found");
            return user;
        }
    }
}