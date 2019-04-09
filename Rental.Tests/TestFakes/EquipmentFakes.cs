using Rental.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rental.Tests.TestFakes
{
    public class Constants
    {
        public static string InventoryItemName => "KamAZ Truck";
        public static int DaysToRent => 7;
    }
    public class FakeEquipmentRepository : EquipmentRepositoryBase
    {
        public FakeEquipmentRepository() : base()
        {
            EquipmentFactory factory = new EquipmentFactory();

            Equipments = new List<Equipment>
            {
                factory.CreateEquipment("Bulldozer", EquipmentType.Heavy),
                factory.CreateEquipment(Constants.InventoryItemName, EquipmentType.Heavy)
            };

        }
    }
}
