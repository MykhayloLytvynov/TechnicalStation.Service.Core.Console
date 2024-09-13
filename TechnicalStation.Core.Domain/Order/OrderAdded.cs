using Common.Domain.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalStation.Core.Domain.Order
{
    public class OrderAdded : DomainEventBase
    {
        public OrderAdded(int orderId, int customerId, int carId, DateTime startDate, DateTime finishDate, DateTime ModifyTime)
        {
            this.OrderId = orderId;
            this.CustomerId = customerId;
            this.CarId = carId;
            this.StartDate = startDate;
            this.FinishDate = finishDate;
            this.ModifyTime = ModifyTime;
        }

        public int OrderId { get; private set; }
        public int CustomerId { get; private set; }
        public int CarId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime FinishDate { get; private set; }
        public DateTime ModifyTime { get; private set; }
    }
}
