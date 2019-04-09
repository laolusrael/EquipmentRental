using System.Threading.Tasks;

namespace Rental.BL
{
    public interface ICartManager
    {
        Task<ICart> GetCartByCustomerNumberAsync(string customerNumber);
        Task<ICartItem> AddItemToCartAsync(Equipment equipment, int numOfDays);
    }
}
