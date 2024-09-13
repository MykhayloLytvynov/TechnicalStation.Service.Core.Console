using System;
using System.Collections.Generic;
using System.Text;
using Common.Domain;
using Common.Domain.Event;

namespace TechnicalStation.Core.Domain.Car
{
    public class CarAdded : DomainEventBase
    {
        public CarAdded(int carId, int customerId, string producer, string model, string color, string number, int year)
        {
            this.CarId = carId;
            this.CustomerId = customerId;
            this.Producer = producer;
            this.Model = model;
            this.Color = color;
            this.Number = number;
            this.Year = year;
        }

        public int CarId { get; private set; }
        public int CustomerId { get; private set; }
        public string Producer { get; private set; }
        public string Model { get; private set; }
        public string Color { get; private set; }
        public string Number { get; private set; }
        public int Year { get; private set; }
    }
}
