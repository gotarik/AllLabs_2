using System.ComponentModel.DataAnnotations;

public class Administrator : Person
{
    [Key]
    public Guid AdministratorIdPK { get; set; }

    public Guid RentalSystemIdFK { get; set; }

    public RentalSystem RentalSystems { get; set; }

    public Administrator(string name = "", string passportData = "") : base(name, passportData)
    {
        this.AdministratorIdPK = AdministratorIdPK;
    }
    public string ApproveOrder(Order order)
    {
        order.ChangeStatus("Approved");
        return "Order approved";
    }
    public string RejectOrder(Order order, string reason)
    {
        order.ChangeStatus("Rejected");
        order.RejectionReason = reason;
        return $"Order rejected: {reason}";
    }
    public string MarkDamage(Order order, string damageDescription)
    {
        order.DamageDescription = damageDescription;
        return $"Damage noted: {damageDescription}";
    }
    public override string ToString()
    {
        return $"Administrator: {Name}";
    }
}