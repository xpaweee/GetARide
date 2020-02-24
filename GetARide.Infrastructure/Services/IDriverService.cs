using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GetARide.Infrastructure.DTO;

namespace GetARide.Infrastructure.Services
{
    public interface IDriverService : IService
    {
        Task<DriverDetailsDto> Get(Guid UserId);
        Task CreateAsync(Guid userId);
        Task SetVehicle(Guid userId,string brand, string name);
        Task DeleteAsync(Guid userId);
        Task<IEnumerable<DriverDto>> BrowseAsync();
    }
}