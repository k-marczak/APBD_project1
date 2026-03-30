namespace APBD_project1.Models;

public class Projector : Device
{
    public int VideoFormat { get; set; }
    public bool SpeakerMounted { get; set; }

    public Projector(string name, int videoFormat, bool speakerMounted) : base(name)
    {
        VideoFormat = videoFormat;
        SpeakerMounted = speakerMounted;
    }
    
    public override string ToString()
    {
        return "Projektor: " + "Id: " + Id + ", Nazwa: " + Name + ", Status: " + Status;
    }
}