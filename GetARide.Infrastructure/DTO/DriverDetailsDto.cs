using System.Collections.Generic;

namespace GetARide.Infrastructure.DTO
{
    public class DriverDetailsDto : DriverDto
    {
        public IEnumerable<RouteDto> Routes{get;set;}
    }
}