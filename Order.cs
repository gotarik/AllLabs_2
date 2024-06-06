using AllLabs_2;
using System.ComponentModel.DataAnnotations;

public class Order 
{
    [Key]
    public Guid OrderIdPK { get; set; }   

    public int RentalPeriod { get; set; }
    public string Status { get; set; }
    public string RejectionReason { get; set; }
    public string DamageDescription { get; set; }

    public Guid ClientIdFK { get; set; }
    public Guid CarIdFK { get; set; }

    public Client Client { get; set; }
    public Car Car { get; set; }
    public event OrderStatusChanged OrderStatusChangedEvent;

    public Order(Guid ClientIdFK, Guid CarIdFK, int rentalPeriod)
    {
        this.ClientIdFK = ClientIdFK;
        this.CarIdFK = CarIdFK;
        RentalPeriod = rentalPeriod;
        Status = "Pending";
        RejectionReason = "";
        DamageDescription = "";
    }

    public void ChangeStatus(string newStatus)
    {
        string oldStatus = Status;
        Status = newStatus;
        OnOrderStatusChanged(oldStatus, newStatus);
    }
    public virtual void OnOrderStatusChanged(string oldStatus, string newStatus)
    {
        OrderStatusChangedEvent?.Invoke(this, oldStatus, newStatus);
    }
    public string GetOrderInfo()
    {
        if (Status == "Approved")
        {
            return $"Client: {Client.GetInfo()},\nCar: {Car.GetCarInfo()},\nRental Period: {RentalPeriod} days,\nStatus: {Status},\n";
        }
        else
        {
            return $"Client: {Client.GetInfo()},\nCar: {Car.GetCarInfo()},\nRental Period: {RentalPeriod} days,\nStatus: {Status},\nRejection Reason: {RejectionReason},\nDamage Description: {DamageDescription}\n";
        }
    }
    public override string ToString()
    {
        return $"Order: Client {Client.Name},\nCar {Car.Model},\nPeriod {RentalPeriod} days";
    }

}
    
    
