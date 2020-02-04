using System;
using System.Collections.Generic;
using GetARide.Core.Domain;
using GetARide.Core.Repositories;
using GetARide.Infrastructure.DTO;

namespace GetARide.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private  readonly IDriverRepository _driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }
        public DriverDto Get(Guid UserId)
        {
            var drivers = _driverRepository.Get(UserId);
            return new DriverDto
            {

            };
        }
    }
}