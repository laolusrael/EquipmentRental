using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentRental.FrontEnd.Models
{
    public class EquipmentModel
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public EquipmentType EquipmentType { get; set; }
        public string Name { get; set; }
    }


    public enum EquipmentType
    {
        Abstract, Heavy, Regular, Specialized
    }


    public class CartItemModel
    {

        public Guid EquipmentId { get; set; }
        public int NumberOfDays { get; set; }
    }

    public class CartItemWithCostModel:CartItemModel {

        public double Cost { get; set; }
        public Currency Currency { get;set; }

    }


    public enum Currency
    {
        Sterling, Euro, USD, Naira
    }
}
