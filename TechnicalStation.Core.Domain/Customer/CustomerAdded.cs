using Common.Domain.Event;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TechnicalStation.Core.Domain.Customer
{
    public class CustomerAdded : DomainEventBase
    {
        public CustomerAdded(int customerId, string firstName, string lastName, string address, string phoneNumber) 
        {
            this.CustomerId = customerId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
        }

        public int CustomerId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }

    }
}
