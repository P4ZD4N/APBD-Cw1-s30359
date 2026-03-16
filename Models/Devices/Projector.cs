namespace APBD_Cw1_s30359.Models.Devices;

public class Projector {
    public int Id { get; }
    
    private static int _projectorCount = 1;

    public Projector()
    {
        Id = _projectorCount;
        _projectorCount++;
    }
}