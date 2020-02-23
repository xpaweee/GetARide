using System;
using System.Collections.Generic;
using GetARide.Core.Domain;
namespace GetARide.Core.Domain
{
    public class Driver
    {
        public Guid UserId{get;protected set;}
        public string Name {get;protected set;}
        public Vehicle Vehicle{get;protected set;}

        public IEnumerable<Route> Routes {get; protected set;}

        public IEnumerable<DailyRoute> DailyRoutes {get; protected set;}

        protected Driver()
        {
            
        }

        public Driver(User user)
        {
            UserId = UserId;
            Name = user.Username;
        }

        public void SetVehicler(string brand, string name, int seats)
        {
            Vehicle = new Vehicle(name,seats,brand);
        }
    }
}