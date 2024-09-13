using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Org.BouncyCastle.Utilities;
using TechnicalStation.Core.BLL.Contract;
using TechnicalStation.Core.BLL.IntegrationTest.Context;
using TechnicalStation.Core.DAL.Contract;
using TechnicalStation.Core.Domain.Car;

namespace TechnicalStation.Core.BLL.IntegrationTest
{
    [TestFixture]
    public class CarServiceTester
    {
        [Test]
        public async Task GetCarColletion() 
        {
            var carService = TestingContext.GetService<ICarService>();

            // Act
            var result = await carService.GetCollectionAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count >= 0);

        }

        [Test]
        public async Task AddNewCar()
        {
            var carService = TestingContext.GetService<ICarService>();

            // Arrange
            var carToAdd = new Car
            {
                CustomerId = 1,
                Producer = "Toyota",
                Model = "Camry",
                Color = "Black",
                Number = "ABC123",
                Year = 2024
            };
            

            // Act
            var result = await carService.AddAsync(carToAdd);
            // Assert
            Assert.AreEqual(carToAdd, result);
            
        }

        [Test]
        public async Task UpdateCar()
        {
            var carService = TestingContext.GetService<ICarService>();

            // Arrange
            var carToUpdate = new Car
            {
                Id = 14,
                CustomerId = 1,
                Producer = "Mazda",
                Model = "Camry",
                Color = "White",
                Number = "ABC123",
                Year = 2024
            };


            // Act
            var result = await carService.UpdateAsync(carToUpdate);
            // Assert
            Assert.AreEqual(carToUpdate, result);

        }

        [Test]
        public async Task DeleteCar()
        {
            var carService = TestingContext.GetService<ICarService>();

            // Arrange
            var carToAdd = new Car
            {
                CustomerId = 1,
                Producer = "Toyota",
                Model = "Camry",
                Color = "Black",
                Number = "ABC123",
                Year = 2024
            };


            // Act
            var addedCar = await carService.AddAsync(carToAdd);

            await carService.RemoveAsync(addedCar.Id);

            var exception = Assert.ThrowsAsync<Exception>(async () => await carService.GetAsync(addedCar.Id));
            Assert.NotNull(exception);
        }

    }
}
