using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetARide.Core.Domain;
using GetARide.Core.Repositories;

namespace GetARide.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
             private static ISet<Vehicle> _vehicles = new HashSet<Vehicle>
        {
            new Vehicle("TestName",10,"Brand 1"),
            new Vehicle("TestName2",10,"Brand 2"),
            new Vehicle("TestName3",10,"Brand 3"),
            new Vehicle("TestName4",10,"Brand 4"),

        };

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
            => await Task.FromResult(_vehicles);

        public async Task<Vehicle> GetVehicleAsync(string name)
        => await Task.FromResult(_vehicles.SingleOrDefault(x=> x.Name == name));

        public async Task AddVehicleAsync(string name, int seats)
        {
            var vehicle = new Vehicle(name,seats);
            await Task.FromResult(_vehicles.Add(vehicle)); 
        }

        public async Task AddVehicleAsync(Vehicle vehicle)
            => await Task.FromResult(_vehicles.Add(vehicle));
    }
}