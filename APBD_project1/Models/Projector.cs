namespace APBD_project1.Models;

public class Projector : Device
{
    public int VideoFormat { get; set; }
    public bool SpeakerMounted { get; set; }

    protected Projector(string name, int videoFormat, bool speakerMounted) : base(name)
    {
        VideoFormat = videoFormat;
        SpeakerMounted = speakerMounted;
    }
}