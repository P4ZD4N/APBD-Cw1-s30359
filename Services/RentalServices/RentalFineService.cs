using APBD_Cw1_s30359.Models.Rentals;

namespace APBD_Cw1_s30359.Services.RentalServices;

public class RentalFineService : IFineService
{
    private const decimal FinePerDay = 5m;

    public void CheckIfFineNecessary(Rental rental, DateTime realRentalEnd)
    {
        var difference = realRentalEnd - rental.RentalEnd; 
        
        if (realRentalEnd > rental.RentalEnd)
        {
            var lateDays = (int) Math.Ceiling(difference.TotalDays); 
            var totalFine = lateDays * FinePerDay;

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