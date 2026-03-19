using APBD_Cw1_s30359.models.rentals;

namespace APBD_Cw1_s30359.Services;

public class RentalFineService(Rental rental)
{
    public void CheckIfFineNecessary(DateTime realRentalEnd)
    {
        var difference = realRentalEnd - rental.RentalEnd; 
        
        if (realRentalEnd > rental.RentalEnd)
        {
            var lateDays = (int) Math.Ceiling(difference.TotalDays); 
            var finePerDay = 5m; 
            var totalFine = lateDays * finePerDay;

            Console.WriteLine(
                $"[{rental.Renter.FirstName} {rental.Renter.LastName}] " +
                $"Ended rental {lateDays} days after deadline, fine: {totalFine} PLN");
        }
        else
        {
            Console.WriteLine(
                $"[{rental.Renter.FirstName} {rental.Renter.LastName}] " +
                $"Ended rental before deadline");
        }
    }
}