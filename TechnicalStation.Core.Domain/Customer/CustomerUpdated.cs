using Common.Domain.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalStation.Core.Domain.Customer
{
    public class CustomerUpdated : DomainEventBase
    {
        public CustomerUpdated(int customerId, string oldFirstName, string firstName, string oldLastName,string lastName, string oldAddress, string address,string oldPhoneNumber, string phoneNumber)
        {
            this.CustomerId = customerId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.OldFirstName = oldFirstName;
            this.OldLastName = oldLastName;
            this.OldAddress = oldAddress;
            this.OldPhoneNumber = oldPhoneNumber;

        }

        public int CustomerId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public string OldFirstName { get; private set; }
        public string OldLastName { get; private set; }
        public string OldAddress { get; private set; }
        public string OldPhoneNumber { get; private set; }
    }
}
