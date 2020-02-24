using System;
using GetARide.Infrastructure.Commands.Models;

namespace GetARide.Infrastructure.Commands.Driver
{
    public class UpdateDriver : AuthenticatedCommandBase
    {
        public DriverVehicle Vehicle {get;set;}
    }
}