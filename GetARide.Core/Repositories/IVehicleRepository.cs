using System.Collections.Generic;
using System.Threading.Tasks;
using GetARide.Core.Domain;

namespace GetARide.Core.Repositories
{
    public interface IVehicleRepository : IRepository
    {
         Task<Vehicle> GetVehicleAsync(string name);
         Task AddVehicleAsync(string name, int seats);
         Task AddVehicleAsync(Vehicle vehicle);

         Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();
    }
}