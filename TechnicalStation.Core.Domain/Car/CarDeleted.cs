using Common.Domain.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalStation.Core.Domain.Car 
{
    public class CarDeleted : DomainEventBase
    {
        public CarDeleted(int carId, int customerId)
        {
            this.CarId = carId;
            this.CustomerId = customerId;
        }

        public int CarId { get; private set; }
        public int CustomerId { get; private set; }
    }
}
