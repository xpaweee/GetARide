using System;
using GetARide.Core.Domain;

namespace GetARide.Infrastructure.DTO
{
    public class DriverDto
    {
        public Guid UserId{get;protected set;}
        public Vehicle Vehicle{get;protected set;}
    }
}