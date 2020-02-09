using System;
using GetARide.Infrastructure.DTO;

namespace GetARide.Infrastructure.Services
{
    public interface IDriverService : IService
    {
         DriverDto Get(Guid UserId);
    }
}