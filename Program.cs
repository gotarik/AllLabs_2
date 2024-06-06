using AllLabs_2;

class Program
{
    private static int GenerateRandomId()
    {
        var random = new Random();
        return random.Next(100000, 1000000);
    }
    
    static void Main(string[] args)
    {
        int id = GenerateRandomId();

        using (var db = new carsystemDBcontext())
        {
            if (!db.RentalSystems.Any())
            {
                Console.Write("Enter a name for a new Car Rental System: ");
                var name = Console.ReadLine();
                var rental = new RentalSystem { Name = name};

                db.RentalSystems.Add(rental);
                db.SaveChanges();

                Console.WriteLine("New Car Rental System created.");
            }
            else
            {
                Console.WriteLine("Car Rental System already exists.");
            }

            var query = from r in db.RentalSystems
                        orderby r.Name
                        select r;
            Console.WriteLine("All car rental systems in the database:");
            foreach (var item in query)
            {
                Console.WriteLine(item.Name);
            }

            var rentalSystem = db.RentalSystems.First();

            //Console.Write("Enter a name for a new Administrator: ");
            //var adminName = Console.ReadLine();
            //var adminId = id.ToString();
            //var admin = new Administrator(adminName, adminId);

            //admin.RentalSystemIdFK = rentalSystem.RentalSystemIdPK;
            //admin.RentalSystems = rentalSystem;

            //db.Administrators.Add(admin);
            //db.SaveChanges();
            //Console.WriteLine("New Administrator added.");

            //Console.Write("Enter a name for a new Client: ");
            //var clientName = Console.ReadLine();
            //var clientIdPK = id.ToString();
            //var client = new Client(clientName, clientIdPK);

            //client.RentalSystemIdFK = rentalSystem.RentalSystemIdPK;
            //client.RentalSystems = rentalSystem;

            //db.Clients.Add(client);
            //db.SaveChanges();
            //Console.WriteLine("New Client added.");

            //Console.Write("Enter a model for a new Car: ");
            //var carModel = Console.ReadLine();
            //Console.Write("Enter a license plate for a new Car: ");
            //var carLicensePlate = Console.ReadLine();
            //var car = new Car(carModel, carLicensePlate); 

            //car.RentalSystemIdFK = rentalSystem.RentalSystemIdPK;
            //car.RentalSystems = rentalSystem;

            //db.Cars.Add(car);
            //db.SaveChanges();
            //Console.WriteLine("New Car added.");

            //Console.Write("Enter rental period for a new Order: ");
            //int rentalPeriod = int.Parse(Console.ReadLine());
            //var caridfk = db.Cars.First().CarIdPK;
            //var clidfk = db.Clients.First().Id;
            //var order = new Order(clidfk, caridfk, rentalPeriod);

            //db.Orders.Add(order);
            //db.SaveChanges();
            //Console.WriteLine("New Order added.");

            //LINQ - where(find passportdata by name)
            var queryClient = from cl in db.Clients
                              where cl.Name == "Hunter"
                              select cl;
            Console.WriteLine("\nAll clients passportdata by name Hunter:");
            foreach (var item in queryClient)
            {
                Console.WriteLine(item.PassportData);
            }
            //LINQ - group
            var ordersGroupedByStatus = from o in db.Orders
                                        group o by o.Status into statusGroup
                                        select new
                                        {
                                            Status = statusGroup.Key,
                                            OrderCount = statusGroup.Count()
                                        };
            Console.WriteLine("\nThis code provides a concise way to analyze\n" +
                              "and visualize the distribution of orders by\n" +
                              "their status in your database");
            foreach (var group in ordersGroupedByStatus)
            {
                Console.WriteLine($"\nStatus: {group.Status}, Order Count: {group.OrderCount}\n");
            }
            //LINQ - join
            //Show all client`s orders with name "John Doe" with info about car
            var HunterOrderQuery = from o in db.Orders
                                join cl in db.Clients on o.ClientIdFK equals cl.Id
                                where cl.Name == "Hunter"
                                select new
                                {
                                    ClientName = cl.Name,
                                    CarModel = o.Car.Model,
                                    RentalPeriod = o.RentalPeriod.ToString(),
                                    OrderStatus = o.Status
                                };

            if (HunterOrderQuery.Any())
            {
                foreach (var o in HunterOrderQuery)
                {
                    Console.WriteLine($"Client: {o.ClientName}, \nCar Model: {o.CarModel}, \nRental Period: {o.RentalPeriod} days, \nStatus: {o.OrderStatus}");
                }
            }
            else
            {
                Console.WriteLine("No orders found for Hunter.");
            }


            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
