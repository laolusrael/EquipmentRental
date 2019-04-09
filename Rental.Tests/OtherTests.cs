using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using Rental.BL;

namespace Rental.Tests
{
    [TestClass]
    public class OtherTests
    {
        IEquipmentInventory _inventory;
        IEnumerable<Equipment> _equipments;
        Customer _customer;
        [TestInitialize]
        public void Initialize()
        {

            _inventory = new EquipmentInventory(new FileBasedEquipmentRepository(new FakeLogger<FileBasedEquipmentRepository>(), new EquipmentFactory(), ".\\equipment_repository.txt"));
            _equipments = _inventory.GetAvailableEquipments();

            _customer = new Customer("Fake Customer", "0280382302");


        }
        [TestMethod]
        public void ShouldEnsureFileBasedRepositoryIsProperlyLoaded()
        {

            Assert.IsTrue(_equipments.Any());
        }

        [TestMethod]
        public void ShouldEnsureRegularItemRentalCostIsCorrect()
        {

            var cart = new Cart(_customer);
            cart.AddItem(
                new CartItem(
                    _equipments.FirstOrDefault(e => e.EquipmentType == EquipmentType.Regular)
                    , 2)
                    );


            Assert.AreEqual(cart.Items.FirstOrDefault().Cost.Fee, 220.00);


            cart.Items.FirstOrDefault().SetDays(5);

            Assert.AreEqual(cart.Items.FirstOrDefault().Cost.Fee, 340.00);
        }
    }
                 

    internal class FakeLogger<TEntity> : ILogger<TEntity>, IDisposable
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return this;
        }

        public bool IsEnabled(Microsoft.Extensions.Logging.LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(Microsoft.Extensions.Logging.LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            Console.WriteLine("Logger committed");
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            Dispose(true);
        }
        #endregion
    }

    

}
