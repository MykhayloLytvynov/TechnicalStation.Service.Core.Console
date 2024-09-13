using Common.Domain.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalStation.Core.Domain.Work
{
    public class WorkUpdated : DomainEventBase
    {
        public WorkUpdated(int workId, int orderId, int workerId)
        {
            this.WorkId = workId;
            this.OrderId = orderId;
            this.WorkerId = workerId;
        }

        public int WorkerId { get; private set; }
        public int WorkId { get; private set; }
        public int OrderId { get; private set; }
    }
}
