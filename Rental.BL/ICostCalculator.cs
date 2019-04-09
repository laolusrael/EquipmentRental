namespace Rental.BL
{
    public interface ICostCalculator
    {
        IRentalFee GetRentalCost(int numberOfDays, Currency currency = Currency.Euro);
    }

}
