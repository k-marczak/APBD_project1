namespace APBD_project1.Models;

public class Camera : Device
{
    public int Resolution { get; set; }
    public bool IsFullHD { get; set; }

    public Camera(string name, int resolution, bool isFullHd) : base(name)
    {
        Resolution = resolution;
        IsFullHD = isFullHd;
    }
}