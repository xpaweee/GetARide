using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GetARide.Core.Domain;

namespace GetARide.Core.Repositories
{
    public interface IDriverRepository : IRepository
    {
         Task<Driver> Get(Guid UserId);

         Task<IEnumerable<Driver>> BrowseAsync();

         Task Add(Driver driver);
         Task Update(Driver driver);
         Task DeleteAsync(Driver driver);
    }
}