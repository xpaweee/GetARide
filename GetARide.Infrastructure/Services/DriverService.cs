using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GetARide.Core.Domain;
using GetARide.Core.Repositories;
using GetARide.Infrastructure.DTO;

namespace GetARide.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private  readonly IDriverRepository _driverRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IVehicleProvider _vehicleProvider;

        public DriverService(IDriverRepository driverRepository,IUserRepository userRepository ,IMapper mapper, IVehicleProvider vehicleProvider)
        {
            _driverRepository = driverRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _vehicleProvider = vehicleProvider;
        }

        public async Task<IEnumerable<DriverDto>> BrowseAsync()
        {
            var drivers = await _driverRepository.BrowseAsync();

            return _mapper.Map<IEnumerable<Driver>, IEnumerable<DriverDto>>(drivers);
        }

        public async Task CreateAsync(Guid userId)
        {
            var user = await _userRepository.GetUserAsync(userId);
            if(user is null )
                throw new Exception($"User with id: {userId} was not found");
            
            var driver = await _driverRepository.Get(userId);
            if(driver is {} )
                throw new Exception($"Driver with id: {userId} was not found");
            driver = new Driver(user);
            await _driverRepository.Add(driver);
            
        }

        public async Task<DriverDetailsDto> Get(Guid UserId)
        {
            var drivers = await _driverRepository.Get(UserId);
            return _mapper.Map<Driver,DriverDetailsDto>(drivers);
            
        }

        public async Task SetVehicle(Guid userId, string brand, string name)
        {
            var driver = await _driverRepository.Get(userId);
            if(driver is null )
                throw new Exception($"Driver with id: {userId} was not found");

            var vehicleDetails = await _vehicleProvider.GetAsync(brand,name);
            var vehicle = new Vehicle(name,vehicleDetails.Seats,brand);
            driver.SetVehicle(vehicle);
            //await _driverRepository.Update(driver);
        }
    }
}