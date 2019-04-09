using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Text;

namespace Rental.BL
{
    public abstract class Equipment : IEquipment, ICostCalculator
    {
        private string _name;
        public EquipmentType EquipmentType { get; set; }
        public string Name => _name;

        protected Equipment(string name)
            : this(Guid.NewGuid(), name, true, DateTime.UtcNow, DateTime.UtcNow)
        {
        }
        protected Equipment(Guid id, string name, bool isAvailable, DateTime dateCreated, DateTime dateModified)
        {
            _name         = name;
            EquipmentType = EquipmentType.Abstract;
            IsAvailable   = true;
            DateCreated   = dateCreated;
            DateModified  = dateModified;
            Id            = id;
        }

        /// <summary>
        /// Calculate the cost of rental for the type of equipment. 
        /// Implementation for this is provided by the deriving class 
        /// </summary>
        /// <param name="numberOfDays">number of rent days</param>
        /// <param name="currency">currency of the money</param>
        /// <returns></returns>
        public abstract IRentalFee GetRentalCost(int numberOfDays, Currency currency = Currency.Euro);

        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var objC = (Equipment)obj;

            return
                Name.Equals(objC.Name)
                && EquipmentType.ToString().Equals(objC.EquipmentType.ToString());
        }

        public override int GetHashCode()
        {
            return
                (Name + EquipmentType.ToString())
                .GetHashCode();
        }

        public bool IsAvailable { get; set; }
        public Guid Id { get; protected set; }
        public DateTime DateCreated { get; protected set; }
        public DateTime DateModified { get; protected set; }
    }

}
