using System;
using System.Collections.Generic;
using System.Linq;
using GetARide.Core.Domain;
namespace GetARide.Core.Domain
{
   public class Driver
    {
        private ISet<Route> _routes = new HashSet<Route>();
        private ISet<DailyRoute> _dailyRoutes = new HashSet<DailyRoute>();

        public Guid UserId { get; protected set; }
        public string Name { get; protected set; }
        public double Distance { get; protected set; }
        public Vehicle Vehicle { get; protected set; }
        public DateTime UpdatedAt { get; private set; }
        public IEnumerable<Route> Routes
        {
            get { return _routes; }
            set { _routes = new HashSet<Route>(value); }
        }
        public IEnumerable<DailyRoute> DailyRoutes
        {
            get { return _dailyRoutes; }
            set { _dailyRoutes = new HashSet<DailyRoute>(value); }
        }

        protected Driver() 
        {
        }

        public Driver (User user)
        {
            UserId = user.Id;
            Name = user.Username;
            AddRoute("Testowa sciezka",new Node("Startowy adres",2,2),new Node("Koncowy adres",4,4),new Random().Next(1000,100000));
        }

        public void SetVehicle(Vehicle vehicle)
        {
            Vehicle = vehicle;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddRoute(string name, Node start, Node end, double distance)
        {
            var route = Routes.SingleOrDefault(x => x.Name == name);
            if(route != null)
            {
                throw new Exception($"Route with name: '{name}' already exists for driver: {Name}.");
            }
            if(distance < 0)
                throw new Exception($"Route can not have negative distance.");
            _routes.Add(Route.Create(name, start, end,distance));
            UpdatedAt = DateTime.UtcNow;
        }

        public void DeleteRoute(string name)
        {
            var route = Routes.SingleOrDefault(x => x.Name == name);
            if(route == null)
            {
                throw new Exception($"Route named: '{name}' for driver: '{Name}' was not found.");
            }
            _routes.Remove(route);
            UpdatedAt = DateTime.UtcNow;            
        }
    }
}