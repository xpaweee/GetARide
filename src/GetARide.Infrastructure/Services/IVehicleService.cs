using System.Threading.Tasks;
using GetARide.Infrastructure.DTO;

namespace GetARide.Infrastructure.Services
{
    public interface IVehicleService : IService
    {
         Task<VehicleDto> GetAsync(string name);
         Task CreateAsync(string name, int seats);
    }
}