using Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechnicalStation.Core.BLL.Contract;
using TechnicalStation.Core.DAL.Contract;
using TechnicalStation.Core.Domain.Car;
using TechnicalStation.Core.Domain.Customer;
using TechnicalStation.Core.Domain.Order;

namespace TechnicalStation.Core.BLL
{
    public class OrderService : ServiceBase<Order>, IOrderService
    {
        private IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository) : base(orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<Order> AddAsync(Order order)
        {
            await this.orderRepository.AddAsync(order);
            order.AddOrder(order.Id, order.CustomerId, order.CarId, order.StartDate, order.FinishDate, order.ModifyTime);
            await PublishEvents(order.Events);
            Order result = await this.orderRepository.GetByIdAsync(order.Id);

            return result;
        }

        public async Task<Order> UpdateAsync(Order order)
        {
            Order oldValuesOrder = await this.orderRepository.GetByIdAsync(order.Id);
            await this.orderRepository.UpdateAsync(order);
            Order newValuesOrder = await this.orderRepository.GetByIdAsync(order.Id);
            order.UpdateOrder(order.Id, newValuesOrder.CustomerId, oldValuesOrder.CustomerId,
                 newValuesOrder.CarId, oldValuesOrder.CarId, newValuesOrder.StartDate, oldValuesOrder.StartDate, newValuesOrder.FinishDate, oldValuesOrder.FinishDate, newValuesOrder.ModifyTime);
            await PublishEvents(order.Events);


            return newValuesOrder;
        }

        public async Task RemoveAsync(int orderId)
        {
            Order orderToRemove = await this.orderRepository.GetByIdAsync(orderId);
            orderToRemove.DeleteOrder();
            await this.orderRepository.DeleteAsync(orderId);
            await PublishEvents(orderToRemove.Events);
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
