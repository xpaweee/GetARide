using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetARide.Core.Domain;
using GetARide.Infrastructure.DTO;
using Microsoft.Extensions.Caching.Memory;

namespace GetARide.Infrastructure.Services
{
    public class VehicleProvider : IVehicleProvider
    {
        private readonly IMemoryCache _cache;
        private readonly static string CacheKey = "vehicles";

        private static readonly IDictionary<string,IEnumerable<VehicleDetails>> availableVehicles = new Dictionary<string,IEnumerable<VehicleDetails>>
        {
            ["Audi"] = new List<VehicleDetails>
            {
                new VehicleDetails("RS8",6)
            },
            ["BMW"] = new List<VehicleDetails>
            {
                new VehicleDetails("i8",3),
                new VehicleDetails("e36",4)
            },
            ["Ford"] = new List<VehicleDetails>
            {
                new VehicleDetails("Fiesta",6)
            },
            ["Skoda"] = new List<VehicleDetails>
            {
                new VehicleDetails("Fabia",6),
                new VehicleDetails("Rapid",6),
            },
        };

        public VehicleProvider(IMemoryCache cache)
        {
            _cache = cache;
        }
        public async Task<IEnumerable<VehicleDto>> BrowseAsync()
        {
            var vehicles = _cache.Get<IEnumerable<VehicleDto>>(CacheKey);
            if(vehicles is null)
            {
                vehicles = await GetAllAsync();
                _cache.Set(CacheKey,vehicles);
            }

            return vehicles;
        }

        private async Task<IEnumerable<VehicleDto>> GetAllAsync()
            => await Task.FromResult(availableVehicles.GroupBy( x=> x.Key)
            .SelectMany( g=> g.SelectMany ( v => v.Value.Select(c => new VehicleDto
            {
                Brand = v.Key,
                Name = c.Name,
                Seats = c.Seats
            }))));
  
        public async Task<VehicleDto> GetAsync(string brand, string name)
        {
            if(!availableVehicles.ContainsKey(brand))
                throw new Exception($"Vehicle brand: '{brand}' is not available.");

            var vehicles = availableVehicles[brand];
            var vehicle = vehicles.SingleOrDefault( x=> x.Name == name);
            if(vehicle is null)
                throw new Exception($"Vehicle: '{name}' for brand: '{brand}' is not available");

            return await Task.FromResult(new VehicleDto
            {
                Brand = brand,
                Name = vehicle.Name,
                Seats = vehicle.Seats
            });
        }

        public class VehicleDetails
        {
            public int Seats {get;}
            public string Name{get;}

            public VehicleDetails(string name,int seats)
            {
                Seats = seats;
                Name = name;
            }
        }
    }
}