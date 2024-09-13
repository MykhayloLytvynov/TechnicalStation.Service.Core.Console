using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechnicalStation.Core.BLL.Contract;
using TechnicalStation.Core.BLL.IntegrationTest.Context;
using TechnicalStation.Core.Domain.Order;
using TechnicalStation.Core.Domain.Work;

namespace TechnicalStation.Core.BLL.IntegrationTest
{
    [TestFixture]
    public class WorkServiceTester
    {
        [Test]
        public async Task GetWorkColletion()
        {
            var workService = TestingContext.GetService<IWorkService>();

            // Act
            var result = await workService.GetCollectionAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count >= 0);

        }

        [Test]
        public async Task AddNewWork()
        {
            var workService = TestingContext.GetService<IWorkService>();

            // Arrange
            var workToAdd = new Work
            {
                OrderId = 12,
                WorkerId = 5,
                StartDate = DateTime.Now,
                FinishDate = DateTime.Now.AddDays(7),
                Cost = 200,
                SupplyExpenses = 130,
                WorkExpenses = 70,
                Description = "trialDescription",
                Notes = "any notes",
                ModifyTime = DateTime.Now
            };


            // Act
            var result = await workService.AddAsync(workToAdd);

            // Assert
            Assert.AreEqual(workToAdd, result);

        }

        [Test]
        public async Task UpdateWork()
        {
            var workService = TestingContext.GetService<IWorkService>();

            //Arrange
            var workToUpdate = new Work
            {
                Id = 9,
                OrderId = 12,
                WorkerId = 5,
                StartDate = DateTime.Now,
                FinishDate = DateTime.Now.AddDays(8),
                Cost = 200,
                SupplyExpenses = 130,
                WorkExpenses = 70,
                Description = "trialDescription",
                Notes = "any notes for updated object",
                ModifyTime = DateTime.Now
            };


            // Act
            var result = await workService.UpdateAsync(workToUpdate);
            // Assert
            Assert.AreEqual(workToUpdate, result);

        }

        [Test]
        public async Task DeleteWork()
        {
            var workService = TestingContext.GetService<IWorkService>();

            // Arrange
            var workToRemove = new Work
            {
                OrderId = 12,
                WorkerId = 5,
                StartDate = DateTime.Now,
                FinishDate = DateTime.Now.AddDays(8),
                Cost = 200,
                SupplyExpenses = 130,
                WorkExpenses = 70,
                Description = "trialDescription",
                Notes = "any notes for removing",
                ModifyTime = DateTime.Now
            };


            //// Act
            var addedWork = await workService.AddAsync(workToRemove);

            await workService.RemoveAsync(addedWork.Id);

            var exception = Assert.ThrowsAsync<Exception>(async () => await workService.GetAsync(addedWork.Id));
            Assert.NotNull(exception);
        }
    }
}
