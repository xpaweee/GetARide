using System;
using GetARide.Infrastructure.Commands.Models;
using GetARide.Infrastructure.Commands.User;

namespace GetARide.Infrastructure.Commands
{
    public class CreateDriver : AuthenticatedCommandBase
    {
        public DriverVehicle Vehicle{get;set;}


  
    }
}