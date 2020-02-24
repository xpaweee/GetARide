namespace GetARide.Core.Domain
{
    public class PassengerNode
    {
        public Node Node { get; protected set; }
        public Passanger Passenger { get; protected set; }

        protected PassengerNode()
        {
        }

        protected PassengerNode(Passanger passenger, Node node)
        {
            Passenger = passenger;
            Node = node;
        }

        public static PassengerNode Create(Passanger passenger, Node node)
            => new PassengerNode(passenger, node);
    }
}