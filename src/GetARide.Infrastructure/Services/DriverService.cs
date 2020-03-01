using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GetARide.Core.Domain;
using GetARide.Core.Repositories;
using GetARide.Infrastructure.DTO;
using GetARide.Infrastructure.Exceptions;
using GetARide.Infrastructure.Extensions;

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

            return _mapper.Map<IEnumerable<DriverDto>>(drivers);
        }

        public async Task CreateAsync(Guid userId)
        {
            var user = await _userRepository.GetOrFailAsync(userId);

            
            var driver = await _driverRepository.GetOrFailAsync(userId);
            if(driver is {} )
                throw new ServiceException(Exceptions.ErrorCodes.DriverNotFound,$"Driver with id: {userId} was not found");
            driver = new Driver(user);
            await _driverRepository.Add(driver);
            
        }

        public async Task DeleteAsync(Guid userId)
        {
            var driver = await _driverRepository.GetOrFailAsync(userId);
            await _driverRepository.DeleteAsync(driver);
        }

        public async Task<DriverDetailsDto> Get(Guid UserId)
        {
            var drivers = await _driverRepository.Get(UserId);
            return _mapper.Map<DriverDetailsDto>(drivers);
            
        }

        public async Task SetVehicle(Guid userId, string brand, string name)
        {
            var driver = await _driverRepository.GetOrFailAsync(userId);
            var vehicleDetails = await _vehicleProvider.GetAsync(brand,name);
            var vehicle = new Vehicle(name,vehicleDetails.Seats,brand);
            driver.SetVehicle(vehicle);
            //await _driverRepository.Update(driver);
        }
    }
}