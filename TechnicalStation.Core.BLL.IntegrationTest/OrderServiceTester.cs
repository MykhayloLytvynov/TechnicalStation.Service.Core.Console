using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechnicalStation.Core.BLL.Contract;
using TechnicalStation.Core.BLL.IntegrationTest.Context;
using TechnicalStation.Core.Domain.Customer;
using TechnicalStation.Core.Domain.Order;

namespace TechnicalStation.Core.BLL.IntegrationTest
{
    [TestFixture]
    public class OrderServiceTester
    {
        [Test]
        public async Task GetOrderColletion()
        {
            var orderService = TestingContext.GetService<IOrderService>();

            // Act
            var result = await orderService.GetCollectionAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count >= 0);

        }

        [Test]
        public async Task AddNewOrder()
        {
            var orderService = TestingContext.GetService<IOrderService>();

            // Arrange
            var orderToAdd = new Order
            {
                CustomerId = 28,
                CarId = 8,
                StartDate = DateTime.Now,
                FinishDate = DateTime.Now.AddDays(7),
                ModifyTime = DateTime.Now
            };


            // Act
            var result = await orderService.AddAsync(orderToAdd);

            // Assert
            Assert.AreEqual(orderToAdd, result);

        }

        [Test]
        public async Task UpdateOrder()
        {
            var orderService = TestingContext.GetService<IOrderService>();

            //Arrange
            var orderToUpdate = new Order
            {
                Id = 20,
                CustomerId = 1,
                CarId = 1,
                StartDate = DateTime.Now,
                FinishDate = DateTime.Now.AddDays(7),
                ModifyTime = DateTime.Now
            };


            // Act
            var result = await orderService.UpdateAsync(orderToUpdate);
            // Assert
            Assert.AreEqual(orderToUpdate, result);

        }

        [Test]
        public async Task DeleteOrder()
        {
            var orderService = TestingContext.GetService<IOrderService>();

            // Arrange
            //var carToAdd = new Car
            //{
            //    CustomerId = 1,
            //    Producer = "Toyota",
            //    Model = "Camry",
            //    Color = "Black",
            //    Number = "ABC123",
            //    Year = 2024
            //};


            //// Act
            //var addedCar = await carService.AddAsync(carToAdd);

            await orderService.RemoveAsync(23/*addedCustomer.Id*/);

            var exception = Assert.ThrowsAsync<Exception>(async () => await orderService.GetAsync(23/*addedCustomer.Id*/));
            Assert.NotNull(exception);
        }
    }
}
