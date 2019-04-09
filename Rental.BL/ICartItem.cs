namespace Rental.BL
{
    public interface ICartItem 
    {
        IEquipment Equipment { get; }
        void SetDays(int days);
        IRentalFee Cost { get; }
        int NumberOfDays { get; }
    }



}
