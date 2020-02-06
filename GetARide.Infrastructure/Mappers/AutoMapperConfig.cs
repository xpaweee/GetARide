using AutoMapper;
using GetARide.Core.Domain;
using GetARide.Infrastructure.DTO;

namespace GetARide.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
             => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User,UserDto>();
                cfg.CreateMap<Driver,DriverDto>();
                cfg.CreateMap<Vehicle,VehicleDto>();
            })
            .CreateMapper();
        
    }
}