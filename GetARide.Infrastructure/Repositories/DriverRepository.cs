using System;
using System.Collections.Generic;
using System.Linq;
using GetARide.Core.Domain;
using GetARide.Core.Repositories;

namespace GetARide.Infrastructure.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        HashSet<Driver> _drivers = new HashSet<Driver>();
        public void Add(Driver driver)
            => _drivers.Add(driver);
        public Driver Get(Guid UserId)
            => _drivers.Single( x => x.UserId == UserId);

        public IEnumerable<Driver> GetAll()
            => _drivers;

        public void Update(Driver driver)
        {
            throw new NotImplementedException();
        }
    }
}