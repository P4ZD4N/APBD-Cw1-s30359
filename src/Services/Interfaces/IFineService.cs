using APBD_Cw1_s30359.Models.Rentals;

namespace APBD_Cw1_s30359.Services;

public interface IFineService
{
    public void CheckIfFineNecessary(Rental rental, DateTime realRentalEnd);
}