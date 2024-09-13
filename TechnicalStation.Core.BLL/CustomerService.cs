using Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechnicalStation.Core.BLL.Contract;
using TechnicalStation.Core.DAL.Contract;
using TechnicalStation.Core.Domain.Car;
using TechnicalStation.Core.Domain.Customer;

namespace TechnicalStation.Core.BLL
{
    public class CustomerService : ServiceBase<Customer>, ICustomerService
    {
        private ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            await this.customerRepository.AddAsync(customer);
            customer.AddCustomer(customer.Id, customer.FirstName, customer.LastName, customer.Address, customer.PhoneNumber);
            await PublishEvents(customer.Events);
            Customer result = await this.customerRepository.GetByIdAsync(customer.Id);

            return result;
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            Customer oldValuesCustomer = await this.customerRepository.GetByIdAsync(customer.Id);
            await this.customerRepository.UpdateAsync(customer);
            Customer newValuesCustomer = await this.customerRepository.GetByIdAsync(customer.Id);

            customer.UpdateCustomer(customer.Id, oldValuesCustomer.FirstName, customer.FirstName, oldValuesCustomer.LastName, customer.LastName,
                oldValuesCustomer.Address, customer.Address, oldValuesCustomer.PhoneNumber, customer.PhoneNumber);
            await PublishEvents(customer.Events);


            return newValuesCustomer;
        }

        public async Task RemoveAsync(int customerId)
        {
            Customer customerToRemove = await this.customerRepository.GetByIdAsync(customerId);
            customerToRemove.DeleteCustomer();
            await this.customerRepository.DeleteAsync(customerId);
            await PublishEvents(customerToRemove.Events);
        }

        protected async Task PublishEvents(IEnumerable<IDomainEvent> events)
        {
            foreach (var domainEvent in events)
            {
                await Dispatcher.Instance.DispatchAsync(domainEvent);
            }
        }
    }
}
