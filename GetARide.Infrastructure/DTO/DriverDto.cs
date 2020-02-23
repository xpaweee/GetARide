using System;
using GetARide.Core.Domain;

namespace GetARide.Infrastructure.DTO
{
    public class DriverDto
    {
        public Guid UserId{get; set;}
        public string Name{get;set;}
    }
}