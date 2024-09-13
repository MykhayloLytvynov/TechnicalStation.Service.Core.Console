using Common.Domain.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalStation.Core.Domain.Worker
{
    public class WorkerDeleted : DomainEventBase
    {
        public WorkerDeleted(int workerId, string firstName, string lastName)
        {
            this.WorkerId = workerId;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int WorkerId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
       
    }
}
