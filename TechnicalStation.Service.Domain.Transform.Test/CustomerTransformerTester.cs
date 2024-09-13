using NUnit.Framework;
using System;
using TechnicalStation.Core.Domain.Customer;
using TechnicalStation.Service.Domain.Data;

namespace TechnicalStation.Service.Domain.Transform.Test
{
    [TestFixture]
    public class CustomerTransformerTester
    {
        CustomerTransformer customerTransformer = new CustomerTransformer();

        [Test]
        public void Test()
        {
            Customer customer = new Customer()
            {
                Id = 1,
                FirstName = "Petya",
                LastName = "Petrov",
                Address = "Address",
                PhoneNumber = "234567"
            };

            CustomerInfo customerInfo = customerTransformer.Transform(customer);

            Assert.That(customer.FirstName.Equals(customerInfo.FirstName));

            Customer customerResult = customerTransformer.Transform(customerInfo);

            Assert.That(customerResult.FirstName.Equals(customerInfo.FirstName));

        }
    }
}
