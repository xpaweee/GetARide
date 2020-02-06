using System.Threading.Tasks;
using AutoMapper;
using GetARide.Core.Domain;
using GetARide.Core.Repositories;
using GetARide.Infrastructure.DTO;

namespace GetARide.Infrastructure.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleReppository;
        private readonly IMapper _mapper;
        public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _vehicleReppository = vehicleRepository;
            _mapper = mapper;
        }
        public async Task CreateAsync(string name, int seats)
        {
            var vehicle = new Vehicle(name,seats);
            await _vehicleReppository.AddVehicleAsync(vehicle);
        }

        public async Task<VehicleDto> GetAsync(string name)
        {
            var vehicle = await  _vehicleReppository.GetVehicleAsync(name);
            return _mapper.Map<Vehicle,VehicleDto>(vehicle);
            
        }
    }
}