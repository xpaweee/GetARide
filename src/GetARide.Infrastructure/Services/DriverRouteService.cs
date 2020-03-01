using System;
using System.Threading.Tasks;
using AutoMapper;
using GetARide.Core.Domain;
using GetARide.Core.Repositories;

namespace GetARide.Infrastructure.Services
{
    public class DriverRouteService : IDriverRouteService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IRootManager _routeManager;
        private readonly IMapper _mapper;
        public DriverRouteService(IDriverRepository driverRepository, IRootManager routeManager,
                                  IMapper mapper)
        {
            _driverRepository = driverRepository;
            _routeManager = routeManager;
            _mapper = mapper;
        }
        public async Task AddAsync(Guid userId, string name, double startLatitude, double startLongitude, double endLatitude, double endLongitude)
        {
            var driver = await _driverRepository.Get(userId);
            if(driver is null)
                throw new Exception($"Driver with user id: {userId} was not found");
            var startAddres = await _routeManager.GetAddressAsync(startLatitude,startLongitude);
            var endAddres = await _routeManager.GetAddressAsync(endLatitude,endLongitude);
            var start = Node.Create(startAddres,startLongitude,startLatitude);
            var end = Node.Create(endAddres,endLongitude,endLatitude);
            var distance = _routeManager.CalculateLength(startLatitude,startLongitude,endLatitude,endLongitude);
            driver.AddRoute(name,start,end,distance);
            await _driverRepository.Update(driver);
        }

        public async Task DeleteAsync(Guid userId, string name)
        {
            var driver = await _driverRepository.Get(userId);
            if(driver is null)
                throw new Exception($"Driver with user id: {userId} was not found");
            driver.DeleteRoute(name);
            await _driverRepository.Update(driver);
        }
    }
}