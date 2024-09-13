using Common.Domain.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalStation.Core.Domain.Worker
{
    public class WorkerUpdated : DomainEventBase
    {
        public WorkerUpdated(int workerId, string firstName, string lastName, string address, string phoneNumber, string notes, DateTime modifyTime)
        {
            this.WorkerId = workerId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Notes = notes;
            this.ModifyTime = modifyTime;
        }

        public int WorkerId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Notes { get; private set; }
        public DateTime ModifyTime { get; private set; }
    }
}
