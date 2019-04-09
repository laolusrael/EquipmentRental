using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rental.BL;
using Rental.Tests.TestFakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rental.Tests.Equipments
{
    [TestClass]
    public class InventoryTests
    {
        IEquipmentInventory _inventory;
        [TestInitialize]
        public void Initializer() {
            _inventory = new EquipmentInventory(new FakeEquipmentRepository());
        }


        [TestMethod]
        public void EnsureInventoryIsNotEmpty()
        {
            var equipments = _inventory.GetAvailableEquipments();
            Assert.IsTrue(equipments.Any())
;        }

        [TestMethod]
        public void EnsureInventoryHasGivenItem()
        {
            var equipment = _inventory.GetEquipmentByName(Constants.InventoryItemName);
            Assert.AreEqual(Constants.InventoryItemName, equipment.Name);
        }

    }
}
