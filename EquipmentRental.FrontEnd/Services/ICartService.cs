using System.Collections.Generic;
using System.Threading.Tasks;
using EquipmentRental.FrontEnd.Models;

namespace EquipmentRental.FrontEnd.Services
{
    public interface ICartService
    {
        Task AddEquipmentToCartAsync(CartItemModel model);
        Task<IEnumerable<CartItemWithCostModel>> GetCartItemsAsync();
    }
}