using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Domain;
using NUnit.Framework;
using TechnicalStation.Core.DAL.Contract;

namespace TechnicalStation.DAL.Test.Base
{
    [TestFixture]
    public abstract class RepositoryTesterBase<I, T> where I : IRepository<T> where T : Identifiable
    {
        /// <summary>
        /// The dal manager.
        /// </summary>
        protected I repository= TestingContext.GetRepository<I>();

        /// <summary>
        /// Set up test method which gets executed before each test.
        /// </summary>
        [SetUp]
        public  virtual void SetUp()
        {
             this.repository.ClearAsync();
        }


        [Test]
        public async virtual Task GetByIdAsyncTest()
        {
            // Arrange
            T element = this.BuildObject();

            await this.repository.AddAsync(element);

            // Act
            T elementAfter = await this.repository.GetByIdAsync(element.Id);

            // Assert
            Assert.IsTrue(elementAfter.Id > 0);
        }

        /// <summary>
        /// An alternative story of getting object: object was not found.
        /// </summary>
        [Test]
        public async virtual Task GetNotFoundTest()
        {
            try
            {
                await this.repository.GetByIdAsync(38);
                Assert.Fail("Found an object that should not exist.");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(true);
            }
        }

        /// <summary>
        /// The get collection test.
        /// </summary>
        [Test]
        public async virtual Task GetCollectionTest()
        {
            // Arrange
            T element = this.BuildObject();

            await this.repository.AddAsync(element);

            // Act
            List<T> collection = await this.repository.GetCollectionAsync();

            // Assert
            Assert.That(collection.Count, Is.GreaterThanOrEqualTo(1));
        }


        /// <summary>
        /// Basic story of update object function.
        /// </summary>
        [Test]
        public async virtual Task UpdateBasicTest()
        {
            // Arrange
            T element = this.BuildObject();

            // Add object
            await this.repository.AddAsync(element);

            // TODO: Update the object. Fill up fields with testing information using acceptance tests.
            this.ModifyProperties(element);

            // Act
            this.repository.UpdateAsync(element);

            T elementAfter = await this.repository.GetByIdAsync(element.Id);

            // Assert
            element.FieldValuesAreEqual(elementAfter);
        }

        /// <summary>
        /// Basic story of delete object function.
        /// </summary>
        [Test]
        public async virtual Task DeleteBasicTest()
        {
            // Arrange
            T element = this.BuildObject();

            await this.repository.AddAsync(element);
            Assert.IsTrue(element.Id > 0);

            // Act
            await this.repository.DeleteAsync(element.Id);
        }

        /// <summary>
        /// The clear all.
        /// </summary>
        [TearDown]
        public virtual void TearDown()
        {
             this.repository.ClearAsync();
        }

        /// <summary>
        /// The modify properties.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        protected abstract void ModifyProperties(T element);

        /// <summary>
        /// The build object.
        /// </summary>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        protected abstract T BuildObject();
    }
}
