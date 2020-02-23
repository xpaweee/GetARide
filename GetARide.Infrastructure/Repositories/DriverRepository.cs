using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetARide.Core.Domain;
using GetARide.Core.Repositories;

namespace GetARide.Infrastructure.Repositories
{
    public class DriverRepository : IDriverRepository
    {
         private static ISet<Driver> _drivers = new HashSet<Driver>
        {
            new Driver(new User("test","test","test","test")),
            
 

        };


        public async Task<IEnumerable<Driver>> BrowseAsync()
            => await Task.FromResult(_drivers);


        public async Task Update(Driver driver)
        {
            await Task.CompletedTask;
        }

        public async Task Add(Driver driver)
        {
            _drivers.Add(driver);
            await Task.CompletedTask;

        }
        public async Task<Driver> Get(Guid UserId)
            => await Task.FromResult(_drivers.Single( x => x.UserId == UserId));

 

    }
}