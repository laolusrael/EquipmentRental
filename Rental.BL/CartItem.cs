using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Rental.BL
{
    public class CartItem: ICartItem, INotifyPropertyChanged
    {
        private Equipment _equipment;
        public CartItem(Equipment equipment, int numberOfDays) 
        {

            if (numberOfDays < 1)
                throw new ArgumentOutOfRangeException("Number of days must be at least 1");

            this._equipment = equipment;

            SetDays(numberOfDays);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Set the number of days this equipment item will be rented for.
        /// </summary>
        /// <param name="days">number of rent days to set</param>
        public void SetDays(int days)
        {

            days = days < 0 ? 0 : days;
            this.NumberOfDays = days;


            // The item will simply cease to exist from the cart once number of days to rent is 0, 
            // so setting Cost to null is okay.
            Cost = NumberOfDays > 0 ? _equipment.GetRentalCost(days) : null;

            NotifyPropertyChanged();

        }
        /// <summary>
        /// Gets Cost of rent
        /// </summary>
        public IRentalFee Cost { get; private set; }
        /// <summary>
        /// Gets Number of days to rent
        /// </summary>
        public int NumberOfDays { get; private set; }
        /// <summary>
        /// Gets equipment to rent
        /// </summary>
        public IEquipment Equipment => _equipment;
    }



}
