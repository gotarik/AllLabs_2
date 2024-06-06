using System.ComponentModel.DataAnnotations;

public class Car
{
    [Key]
    public Guid CarIdPK { get; set; }
    public string Model { get; set; }
    public string LicensePlate { get; set; }
    public Guid RentalSystemIdFK { get; set; }

    public RentalSystem RentalSystems { get; set; }
    public Order Order { get; set; }

    public Car(string model = "", string licensePlate = "")
    {
        Model = model;
        LicensePlate = licensePlate;
    }

    public string GetCarInfo()
    {
        return $"Model: {Model}, License Plate: {LicensePlate}";
    }
    public void SetCarInfo(string model, string licensePlate)
    {
        Model = model;
        LicensePlate = licensePlate;
    }
}
