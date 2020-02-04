using System;
using GetARide.Infrastructure.DTO;

namespace GetARide.Infrastructure.Services
{
    public interface IDriverService
    {
         DriverDto Get(Guid UserId);
    }
}