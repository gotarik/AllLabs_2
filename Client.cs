using System.ComponentModel.DataAnnotations;

public class Client : Person
{
    [Key]
    public Guid ClientIdPk { get; set; }
    public Guid RentalSystemIdFK { get; set; }

    public RentalSystem RentalSystems { get; set; }
    public List<Order> Orders { get; private set; }

    public Client(string name = "", string passportData = "") : base(name, passportData)
    {
        Orders = new List<Order>();
    }

    public Order CreateOrder(Car car, int rentalPeriod)
    {
        Order order = new Order(ClientIdPk, car.CarIdPK, rentalPeriod)
        {
            Client = this,
            Car = car
        };

        Orders.Add(order);
        car.Order = order; 
        return order;
    }

    public List<Order> GetOrders()
    {
        return Orders;
    }
    public override string ToString()
    {
        return $"Client: {Name}";
    }
}
