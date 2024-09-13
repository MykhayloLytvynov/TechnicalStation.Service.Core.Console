using Common.Domain.Event;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechnicalStation.Core.BLL.Contract;
using TechnicalStation.Core.Domain.Car;
using TechnicalStation.Core.Domain.Customer;
using TechnicalStation.Core.Dto.Enum;
using TechnicalStation.Core.Dto.Notification;

namespace TechnicalStation.Core.BLL.EventHandlers.Customer
{
    public class CustomerAddedThenNotifyCustomerEventHandler : DomainEventHandlerBase<CustomerAdded>
    {
        private INotificationService notificationService;

        public CustomerAddedThenNotifyCustomerEventHandler(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public override async Task HandleAsync(CustomerAdded domainEvent)
        {
            NotificationInfo notificationInfo = new NotificationInfo()
            {
                NotificationType = NotificationType.CustomerAdded,
                AttachedObject = domainEvent
            };

            await this.notificationService.Notify(notificationInfo);
        }
    }
}
