namespace APBD_Cw1_s30359.Models.Devices;

public class Laptop {
    public int Id { get; }
    
    private static int _laptopCount = 1;

    public Laptop()
    {
        Id = _laptopCount;
        _laptopCount++;
    }
}