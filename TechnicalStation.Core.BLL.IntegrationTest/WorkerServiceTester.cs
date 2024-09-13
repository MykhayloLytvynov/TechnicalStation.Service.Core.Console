using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechnicalStation.Core.BLL.Contract;
using TechnicalStation.Core.BLL.IntegrationTest.Context;
using TechnicalStation.Core.Domain.Work;
using TechnicalStation.Core.Domain.Worker;

namespace TechnicalStation.Core.BLL.IntegrationTest
{
    [TestFixture]
    public class WorkerServiceTester
    {
        [Test]
        public async Task GetWorkerColletion()
        {
            var workerService = TestingContext.GetService<IWorkerService>();

            // Act
            var result = await workerService.GetCollectionAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count >= 0);

        }

        [Test]
        public async Task AddNewWorker()
        {
            var workerService = TestingContext.GetService<IWorkerService>();

            // Arrange
            var workerToAdd = new Worker
            {
                FirstName = "TempFirstName1",
                LastName = "TempLastName1",
                Address = "TempAddress1",
                PhoneNumber = "380956768746",
                Notes = "test worker service add",
                ModifyTime = DateTime.Now
            };


            // Act
            var result = await workerService.AddAsync(workerToAdd);

            // Assert
            Assert.AreEqual(workerToAdd, result);

        }

        [Test]
        public async Task UpdateWorker()
        {
            var workerService = TestingContext.GetService<IWorkerService>();

            //Arrange
            var workerToUpdate = new Worker
            {
                Id = 23,
                FirstName = "TempFirstName1",
                LastName = "TempLastName1",
                Address = "TempAddress1",
                PhoneNumber = "380956768746",
                Notes = "test worker service update",
                ModifyTime = DateTime.Now
            };


            // Act
            var result = await workerService.UpdateAsync(workerToUpdate);
            // Assert
            Assert.AreEqual(workerToUpdate, result);

        }

        [Test]
        public async Task DeleteWorker()
        {
            var workerService = TestingContext.GetService<IWorkerService>();

            // Arrange
            var workerToRemove = new Worker
            {
                FirstName = "TempFirstName1",
                LastName = "TempLastName1",
                Address = "TempAddress1",
                PhoneNumber = "380956768746",
                Notes = "test worker service remove",
                ModifyTime = DateTime.Now
            };


            //// Act
            var addedWorker = await workerService.AddAsync(workerToRemove);

            await workerService.RemoveAsync(addedWorker.Id);

            var exception = Assert.ThrowsAsync<Exception>(async () => await workerService.GetAsync(addedWorker.Id));
            Assert.NotNull(exception);
        }
    }
}
