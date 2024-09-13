using Common.Domain.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalStation.Core.Domain.Order
{
    public class OrderUpdated : DomainEventBase
    {
        public OrderUpdated(int orderId, int customerId,  int oldCustomerId, int carId, int oldCarId, DateTime startDate, DateTime oldStartDate, DateTime finishDate, DateTime oldFinishDate, DateTime ModifyTime)
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

        public int oldCustomerId { get; private set; }
        public int oldCarId { get; private set; }
        public DateTime oldStartDate { get; private set; }
        public DateTime oldFinishDate { get; private set; }
        public DateTime oldModifyTime { get; private set; }
    }
}
