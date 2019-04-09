using System;

namespace Rental.BL
{
    public class RegularEquipment : Equipment
    {
        public RegularEquipment(string name) : base(name)
        {
            EquipmentType = EquipmentType.Regular;
        }

        public RegularEquipment(Guid id, string name, bool isAvailable, DateTime dateCreated, DateTime dateModified)
            : base(id, name, isAvailable, dateCreated, dateModified)
        {
            EquipmentType = EquipmentType.Regular;
        }


        public override IRentalFee GetRentalCost(int numberOfDays, Currency currency = Currency.Euro)
        {

            if (numberOfDays < 1)
                throw new ArgumentOutOfRangeException(nameof(numberOfDays));

            var baseFee = new BaseRentalFee(currency);

            if (numberOfDays <= 2)
                return
                    baseFee
                        .Add(new PremiumDaily(numberOfDays, currency));

            baseFee.Add(new PremiumDaily(2, currency));


            return baseFee.Add(new RegularDaily(numberOfDays - 2, currency));

        }
    }

}
