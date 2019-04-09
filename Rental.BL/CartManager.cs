using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rental.BL
{

    public class CartManager : ICartManager
    {
        /// <summary>
        /// Adds the given equipment to customer's cart
        /// </summary>
        /// <param name="equipment">Equipment you are adding</param>
        /// <param name="numOfDays">The number of days to rent</param>
        /// <returns></returns>
        public Task<ICartItem> AddItemToCartAsync(Equipment equipment, int numOfDays)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// TODO: Allow retrieving customer order by customer phone number
        /// </summary>
        /// <param name="customerNumber">Customer Phone Number</param>
        /// <returns></returns>
        public Task<ICart> GetCartByCustomerNumberAsync(string customerNumber)
        {
            throw new NotImplementedException();
        }
    }
}
