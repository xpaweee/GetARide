namespace GetARide.Core.Domain
{
    public class Vehicle
    {
        public string Name{get;protected set;}
        public int Seats{get;protected set;}

        public Vehicle(string name, int seats)
        {
            Name = name;
            Seats = seats;
        }
    }
}