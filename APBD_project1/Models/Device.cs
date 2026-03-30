namespace APBD_project1.Models;

public abstract class Device
{
    private static int id_counter = 0;

    public int Id { get; }
    public string Name { get; set; }
    public bool IsAvailable { get; set; } = true;

    protected Device(string Name)
    {
        Id = id_counter++;
        this.Name = Name;
    }

    public override string ToString()
    {
        return $"{Id}: {Name} (Available: {IsAvailable})";
    }
    
}