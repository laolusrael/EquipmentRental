using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rental.BL;
using Rental.Tests.TestFakes;
using System;
using System.Linq;

namespace Rental.Tests.Equipments
{

    [TestClass]
    public class RentalCartTests
    {
        IEquipmentInventory _inventory;
        ICart _cart;

        [TestInitialize]
        public void Initialzer()
        {
            _inventory = new EquipmentInventory(new FakeEquipmentRepository());
            _cart = new Cart(new Customer("Fake Customer", "123094023"));

        }

        [TestMethod]
        public void ShouldBeAbleToCreateRentalCarts()
        {
            var cart = new Cart(new Customer("Fake Customer", "123094023"));
            Assert.IsInstanceOfType(cart, typeof(ICart));
        }

        [TestMethod]
        public void ShouldBeAbleToAddEquipmentToCart()
        {

            var cart = new Cart(new Customer("Fake Customer", "123094023"));

            Assert.IsFalse(cart.HasItems());


            var equipmentFromInventory = _inventory.GetEquipmentByName(Constants.InventoryItemName);

            Assert.IsNotNull(equipmentFromInventory);



            CartItem item = new CartItem(equipmentFromInventory,Constants.DaysToRent);

            cart.AddItem(item);

            Assert.IsTrue(cart.HasItems());
        }

        [TestMethod]
        public void ShouldEnsureRentalCostOfItemInCartIsCorrect()
        {


            var cart = new Cart(new Customer("Fake Customer", "123094023"));

            var equipmentFromInventory = _inventory.GetEquipmentByName(Constants.InventoryItemName);

            Assert.IsNotNull(equipmentFromInventory);

            CartItem item = new CartItem(equipmentFromInventory, 2);

            cart.AddItem(item);

            Assert.IsTrue(cart.HasItems());

        }

        [TestMethod]
        public void ShouldEnsureDuplicateEquipmentIsNotAdded() {

            var cart = new Cart(new Customer("Fake Customer", "123094023"));

            var equipmentFromInventory = _inventory.GetEquipmentByName(Constants.InventoryItemName);

            Assert.IsNotNull(equipmentFromInventory);

            CartItem item = new CartItem(equipmentFromInventory, Constants.DaysToRent);

            cart.AddItem(item);

            Assert.ThrowsException<ArgumentException>(() => cart.AddItem(item));
        }

        [TestMethod]
        public void ShouldEnsureNumberOfDaysIsProvided() {

            var cart = new Cart(new Customer("Fake Customer", "123094023"));

            var equipmentFromInventory = _inventory.GetEquipmentByName(Constants.InventoryItemName);

            Assert.IsNotNull(equipmentFromInventory);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new CartItem(equipmentFromInventory, 0));

        }

        [TestMethod]
        public void ShouldEnsureItemRemovedWhenNumberOfDaysSetToZero()
        {
            var cart = new Cart(new Customer("Fake Customer", "123094023"));

            var equipmentFromInventory = _inventory.GetEquipmentByName(Constants.InventoryItemName);

            Assert.IsNotNull(equipmentFromInventory);

            CartItem item = new CartItem(equipmentFromInventory, Constants.DaysToRent);

            cart.AddItem(item);

            Assert.IsTrue(cart.HasItems());

            cart.Items
                    .FirstOrDefault(itm => itm.Equals(item))
                    ?.SetDays(0);

           
            Assert.IsFalse(cart.HasItems());




        }
    }
}
