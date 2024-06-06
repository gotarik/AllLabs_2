using System.ComponentModel.DataAnnotations;

public class RentalSystem
{
    [Key]
    public Guid RentalSystemIdPK { get; set; }
    public string Name { get; set; }

    public List<Client> Clients { get; private set; }
    public List<Administrator> Administrators { get; private set; }
    public List<Car> Cars { get; private set; }
    public List<Order> Orders { get; private set; }

    public RentalSystem()
    {
        Clients = new List<Client>();
        Administrators = new List<Administrator>();
        Cars = new List<Car>();
        Orders = new List<Order>();
    }
    public void AddClient(Client client)
    {
        Clients.Add(client);
    }
    public void AddAdministrator(Administrator administrator)
    {
        Administrators.Add(administrator);
    }
    public void AddCar(Car car)
    {
        Cars.Add(car);
    }
    public Order CreateOrder(Client client, Car car, int rentalPeriod)
    {
        Order order = client.CreateOrder(car, rentalPeriod);
        order.OrderStatusChangedEvent += OnOrderStatusChanged;
        Orders.Add(order);
        return order;
    }
    public List<Order> GetOrders()
    {
        return Orders;
    }
    private void OnOrderStatusChanged(Order order, string oldStatus, string newStatus)
    {
        Console.WriteLine($"Order status changed from {oldStatus} to {newStatus} for Order: {order}");
    }
    public override string ToString()
    {
        return $"RentalSystem with {Clients.Count} clients, {Administrators.Count} admins, {Cars.Count} cars";
    }
}
