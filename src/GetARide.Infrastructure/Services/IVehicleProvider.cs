using System.Collections.Generic;
using System.Threading.Tasks;
using GetARide.Core.Domain;
using GetARide.Infrastructure.DTO;

namespace GetARide.Infrastructure.Services
{
    public interface IVehicleProvider : IService
    {
         Task<IEnumerable<VehicleDto>> BrowseAsync();
         Task<VehicleDto> GetAsync(string brand,string name);
    }
}