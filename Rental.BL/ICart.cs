using System.Collections.Generic;

namespace Rental.BL
{
    public interface ICart
    {
        IList<CartItem> Items { get; }
        void AddItem(CartItem item);
        void RemoveItem(CartItem item);
        void CheckOut();
        bool HasItems();

    }



}
