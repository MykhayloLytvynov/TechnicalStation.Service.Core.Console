using Common.Domain.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalStation.Core.Domain.Car
{
    public class CarUpdated : DomainEventBase
    {
        public CarUpdated(int carId, int customerId, string oldProducer, string newProducer, string oldModel, string newModel, string oldColor, string newColor, string oldNumber, string newNumber, int oldYear, int newYear)
        {
            this.CarId = carId;
            this.CustomerId = customerId;
            this.OldProducer = oldProducer;
            this.NewProducer = newProducer;
            this.OldModel = oldModel;
            this.NewModel = newModel;
            this.OldColor = oldColor;
            this.NewColor = newColor;
            this.OldNumber = oldNumber;
            this.NewNumber = newNumber;
            this.OldYear = oldYear;
            this.NewYear = newYear;
        }

        public int CarId { get; private set; }
        public int CustomerId { get; private set; }
        public string OldProducer { get; private set; }
        public string NewProducer { get; private set; }
        public string OldModel { get; private set; }
        public string NewModel { get; private set; }
        public string OldColor { get; private set; }
        public string NewColor { get; private set; }
        public string OldNumber { get; private set; }
        public string NewNumber { get; private set; }
        public int OldYear { get; private set; }
        public int NewYear { get; private set; }
    }
}
