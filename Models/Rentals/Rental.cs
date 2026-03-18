namespace APBD_Cw1_s30359.models.rentals;

public class Rental
{
    public DateTime RentalStart { get; }
    public DateTime RentalEnd { get; set; }

    public Rental(DateTime? rentalStart)
    {
        if (rentalStart != null)
        {
            RentalStart = (DateTime) rentalStart;
            return;
        }
        
        RentalStart = new DateTime();
    }
}