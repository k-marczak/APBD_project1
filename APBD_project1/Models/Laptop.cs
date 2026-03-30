namespace APBD_project1.Models;

public class Laptop : Device
{
    public string Cpu { get; set; }
    public string Gpu { get; set; }
    
    protected Laptop(string name, string gpu, string cpu) : base(name)
    {
        Gpu = gpu;
        Cpu = cpu;
    }
}