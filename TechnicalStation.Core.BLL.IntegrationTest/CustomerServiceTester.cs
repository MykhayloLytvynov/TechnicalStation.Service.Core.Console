using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechnicalStation.Core.BLL.Contract;
using TechnicalStation.Core.BLL.IntegrationTest.Context;
using TechnicalStation.Core.Domain.Car;
using TechnicalStation.Core.Domain.Customer;

namespace TechnicalStation.Core.BLL.IntegrationTest
{
    [TestFixture]
    public class CustomerServiceTester
    {
        [Test]
        public async Task GetCustomerColletion()
        {
            var customerService = TestingContext.GetService<ICustomerService>();

            // Act
            var result = await customerService.GetCollectionAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count >= 0);

        }

        [Test]
        public async Task AddNewCustomer()
        {
            var customerService = TestingContext.GetService<ICustomerService>();

            // Arrange
            var customerToAdd = new Customer
            {
                FirstName = "TrialCustomerFirstName35",
                LastName = "TrialCustomerLastName",
                Address = "TrialCustomerAddress",
                PhoneNumber = "380997343234",
                ModifyTime = DateTime.Now
            };


            // Act
            var result = await customerService.AddAsync(customerToAdd);

            // Assert
            Assert.AreEqual(customerToAdd, result);

        }

        [Test]
        public async Task UpdateCustomer()
        {
            var customerService = TestingContext.GetService<ICustomerService>();

           //Arrange
           var customerToUpdate = new Customer
           {
               Id = 34,
               FirstName = "TrialCustomerFirstName35",
               LastName = "TrialCustomerLastName",
               Address = "TrialCustomerAddress",
               PhoneNumber = "380999343234",
               ModifyTime = DateTime.Now
           };


            // Act
            var result = await customerService.UpdateAsync(customerToUpdate);
            // Assert
            Assert.AreEqual(customerToUpdate, result);

        }

        [Test]
        public async Task DeleteCustomer()
        {
            var customerService = TestingContext.GetService<ICustomerService>();

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

            await customerService.RemoveAsync(35/*addedCustomer.Id*/);

            var exception = Assert.ThrowsAsync<Exception>(async () => await customerService.GetAsync(35/*addedCustomer.Id*/));
            Assert.NotNull(exception);
        }
    }
}
