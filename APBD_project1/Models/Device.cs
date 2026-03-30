using APBD_project1.Enums;

namespace APBD_project1.Models;

public abstract class Device
{
    private static int _idCounter = 0;

    public int Id { get; }
    public string Name { get; set; }
    public DeviceStatus Status { get; set; } 

    protected Device(string name)
    {
        Id = _idCounter++;
        this.Name = name;
        Status = DeviceStatus.Available;
    }

    public override string ToString()
    {
        return "Id: " + Id + ", Nazwa: " + Name + ", Status: " + Status;
    }
    
}