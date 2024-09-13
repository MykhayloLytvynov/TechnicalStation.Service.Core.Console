// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Car.cs" company="DNU">
//  DNU
// </copyright>
// <summary>
//   Defines the Car type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Common.Domain;

namespace TechnicalStation.Core.Domain.Car
{
    using Common.Domain.Entity;
    using System;
    using System.Net.Sockets;


    /// <summary>
    /// The Car
    /// </summary>
    public class Car : EntityBase, Identifiable
    {
        #region Fields

        /// <summary>
        /// Gets or sets the  id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the  customer id
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the  producer
        /// </summary>
        public string Producer { get; set; }

        /// <summary>
        /// Gets or sets the  model
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the  color
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the  number
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the  year
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the  modify time
        /// </summary>
        public DateTime ModifyTime { get; set; } = DateTime.Now;


        #endregion

        public Car() { }

        #region Methods

        public void AddCar(int carId, int customerId, string producer, string model, string color, string number, int year)
        {
            var carAddedEvent = new CarAdded(carId, customerId, producer, model, color, number, year);
            this.AddEvent(carAddedEvent);
        }

        public void DeleteCar()
        {
            var carDeletedEvent = new CarDeleted(this.Id, this.CustomerId);
            this.AddEvent(carDeletedEvent);
        }

        public void UpdateCar(int customerId, string oldProducer, string newProducer, string oldModel, string newModel, string oldColor, string newColor, string oldNumber, string newNumber, int oldYear, int newYear)
        {
            var carUpdatedEvent = new CarUpdated(this.Id, customerId, oldProducer, newProducer, oldModel, newModel, oldColor, newColor, oldNumber, newNumber, oldYear, newYear);
            this.AddEvent(carUpdatedEvent);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var otherCar = (Car)obj;
            return this.Id == otherCar.Id && this.CustomerId == otherCar.CustomerId
                && this.Producer == otherCar.Producer && this.Model == otherCar.Model
                && this.Color == otherCar.Color && this.Number == otherCar.Number
                && this.Year == otherCar.Year;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, CustomerId, Producer, Model, Color, Number, Year);
        }
        #endregion
    }
}