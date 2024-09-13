using Common.Domain.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalStation.Core.Domain.Order
{
    public class OrderDeleted : DomainEventBase
    {
        public OrderDeleted(int orderId, int customerId, int carId) 
        {
            this.OrderId = orderId;
            this.CustomerId = customerId;
            this.CarId = carId;
        }

        public int OrderId { get; private set; }
        public int CustomerId { get; private set; }
        public int CarId { get; private set; }
    }
}
