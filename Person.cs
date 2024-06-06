using System.ComponentModel.DataAnnotations;

public class Person : IPersonActions
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string PassportData { get; set; }

    public Person(string name = "", string passportData = "")
    {
        Name = name;
        PassportData = passportData;
    }
    public string GetInfo()
    {
        return $"Name: {Name}, Passport Data: {PassportData}";
    }
    public void SetInfo(string name, string passportData)
    {
        Name = name;
        PassportData = passportData;
    }
}
