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
    public class CreationalTests
    {
        [TestMethod]
        public void ShouldBeAbleToCreateHeavyEquipmentInstance()
        {
            EquipmentFactory factory = new EquipmentFactory();
            var heavyEquipment = factory.CreateEquipment("Bulldozer", EquipmentType.Heavy);
            Assert.AreEqual(heavyEquipment.GetType(), typeof(HeavyEquipment));
        }
        [TestMethod]
        public void ShouldEnsureHeavyEquipmentsAreNotMistakenForOtherEquipmentTypes() {

            EquipmentFactory factory = new EquipmentFactory();
            IEquipment heavyEquipment = factory.CreateEquipment("Bulldozer", EquipmentType.Regular);
            Assert.AreNotEqual(heavyEquipment.GetType(), typeof(HeavyEquipment));
        }

        IEquipmentInventory inventory;

        [TestInitialize]
        public void SetupFakes()
        {
            inventory = new EquipmentInventory(new FakeEquipmentRepository());
        }


        [TestMethod]
        public void ShouldBeAbleToGetListOfEquipmentsInInventory() { 
            var avialableEquipments = inventory.GetAvailableEquipments();
            Assert.IsTrue(avialableEquipments.Any() );
        }

    }
}


