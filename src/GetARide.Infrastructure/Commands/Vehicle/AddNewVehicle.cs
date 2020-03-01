using System;
using GetARide.Infrastructure.Commands.User;

namespace GetARide.Infrastructure.Commands.Vehicle
{
    public class AddNewVehicle : ICommand
    {
        public string Name {get;set;}
        public int Seats {get;set;}




    }
}