using System;

namespace Rental.BL
{
    public class HeavyEquipment : Equipment
    {
        public HeavyEquipment(string name) : base(name)
        {
            EquipmentType = EquipmentType.Heavy;
        }
        public HeavyEquipment(Guid id, string name, bool isAvailable, DateTime dateCreated, DateTime dateModified)
            : base(id, name, isAvailable, dateCreated, dateModified)
        {
            EquipmentType = EquipmentType.Heavy;
        }


        public override IRentalFee GetRentalCost(int numberOfDays, Currency currency = Currency.Euro)
        {

            if (numberOfDays < 1)
                throw new ArgumentOutOfRangeException(nameof(numberOfDays));

            var baseFee = new BaseRentalFee(currency);

            return baseFee.Add(new RegularDaily(numberOfDays, currency));

        }

    }

}
