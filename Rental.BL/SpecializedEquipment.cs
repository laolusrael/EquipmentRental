using System;

namespace Rental.BL
{
    public class SpecializedEquipment : Equipment
    {

        public SpecializedEquipment(string name) : base(name)
        {
            EquipmentType = EquipmentType.Specialized;
        }
        public SpecializedEquipment(Guid id, string name, bool isAvailable, DateTime dateCreated, DateTime dateModified)
            : base(id, name, isAvailable, dateCreated, dateModified)
        {
            EquipmentType = EquipmentType.Specialized;
        }


        public override IRentalFee GetRentalCost(int numberOfDays, Currency currency = Currency.Euro)
        {

            if (numberOfDays < 1)
                throw new ArgumentOutOfRangeException(nameof(numberOfDays));


            if (numberOfDays <= 3)
                return
                    new PremiumDaily(numberOfDays, currency);

            RentalFee baseFee = (new PremiumDaily(3, currency));


            return baseFee.Add(new RegularDaily(numberOfDays - 3, currency));

        }

    }

}
