using System;
using System.Collections.Generic;
using System.Text;

namespace Rental.BL
{

    public class MoneyConstants {
        public const double NILL = 0.00;
        public const double HUNDRED = 100.00;
        public const double FORTY = 40.00;
        public const double SIXTY = 60.00;
    }

    public class RentalCostCalculator
    {

        public double CalculateCost(IEquipment equipment, int days)
        {
            return 0.00;
        }

    }


    public interface IRentalFee
    {

        double Fee { get; }
        Currency Currency { get; }

    }

    public enum Currency
    {
        Sterling, Euro, USD, Naira
    }

    public abstract class RentalFee:IRentalFee
    {
        protected RentalFee(double fee, Currency currency)
        {
            Fee = fee;
            Currency = Currency;
        }

        public double Fee { get; protected set; }
        public Currency Currency { get; protected set; }

        public RentalFee Add(IRentalFee rentalFee)
        {

            if (this.Currency != rentalFee.Currency)
                throw new InvalidOperationException("Currency must be the same");


            Fee = Fee + rentalFee.Fee;

            return this;
        }
        
    }
    public class NullRentalFee : RentalFee
    {
        public NullRentalFee(Currency currency = Currency.Euro):
            base(MoneyConstants.NILL, currency)
        {

        }
    }
    public class BaseRentalFee : RentalFee
    {
        public BaseRentalFee(Currency currency)
            :base(MoneyConstants.HUNDRED, currency)
        {
        }
    }

    public class PremiumDaily : RentalFee
    {
        public PremiumDaily(Currency currency = Currency.Euro)
            :base(MoneyConstants.SIXTY, currency)
        {
        }

        public PremiumDaily(int days, Currency currency = Currency.Euro)
            :base(MoneyConstants.SIXTY, currency)
        {
            Fee = Fee * days;
        }
    }

    public class RegularDaily: RentalFee
    {

        public RegularDaily(Currency currency = Currency.Euro)
            :base(MoneyConstants.FORTY, currency)
        {
        }

        /// <summary>
        /// Create a Regular daily rental fee
        /// </summary>
        /// <param name="days">Number of days fee will be paid</param>
        /// <param name="currency">Currency of the fee</param>
        public RegularDaily(int days, Currency currency = Currency.Euro)
            :base(MoneyConstants.FORTY, currency)
        {

            Fee = Fee * days;
        }
    }
}
