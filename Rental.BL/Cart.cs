using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental.BL
{

    public class Cart : ICart
    {
        public Cart(Customer customer)
        {
            Customer = customer;
            Items = new List<CartItem>();
        }
        /// <summary>
        /// Gets details of the customer who own this cart
        /// </summary>
        public Customer Customer { get; private set; }
        /// <summary>
        /// Equipments that are in this cart
        /// </summary>
        public IList<CartItem> Items { get; private set; }
        /// <summary>
        /// Adds specified equipment to cart
        /// </summary>
        /// <param name="equipment">Equipment to add to cart</param>
        public void AddItem(CartItem equipment)
        {
           
            var cartItem = Items.FirstOrDefault(item => item.Equipment.Name == equipment.Equipment.Name);

            if (cartItem != null)
            {
                throw new ArgumentException("Item already exists");
            }

            cartItem = equipment;
            Items.Add(cartItem);

            cartItem.PropertyChanged += CartItem_PropertyChanged;

        }

        private void CartItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CartItem cartItem = (CartItem)sender;

            if (cartItem != null)
            {
                if(cartItem.NumberOfDays == 0)
                {
                    Items.Remove(cartItem);
                }
            }
        }

        public void CheckOut()
        {
            throw new NotImplementedException();

        }
        /// <summary>
        /// Gets total cost of this cart
        /// </summary>
        /// <returns></returns>
        public IRentalFee GetTotalCost()
        {

            return
            !Items.Any() ? new NullRentalFee() :

                Items
                    .Aggregate(
                            (RentalFee)(new NullRentalFee()),
                            (fee, item) => fee.Add(item.Cost)
                        ); 


        }

        /// <summary>
        /// Removes the given item from the cart
        /// </summary>
        /// <param name="item"></param>
        public void RemoveItem(CartItem item)
        {
            if (item == null)
                return;


            CartItem cartItem = Items.FirstOrDefault(i => i.Equipment.Equals(item.Equipment));

            if(cartItem != null)
            {
                Items.Remove(cartItem);
            }

        }
        /// <summary>
        /// Indicates if this cart has any items
        /// </summary>
        /// <returns>True if there are items in the cart, false if no item in the cart</returns>
        public bool HasItems() => Items.Any();
    }



}
