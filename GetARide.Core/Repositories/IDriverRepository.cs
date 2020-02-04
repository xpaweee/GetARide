using System;
using System.Collections.Generic;
using GetARide.Core.Domain;

namespace GetARide.Core.Repositories
{
    public interface IDriverRepository
    {
         Driver Get(Guid UserId);

         IEnumerable<Driver> GetAll();

         void Add(Driver driver);
         void Update(Driver driver);
    }
}