using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Event;
using System.Threading.Tasks;
using TechnicalStation.Core.BLL.Contract;
using TechnicalStation.Core.Domain.Car;
using TechnicalStation.Core.Dto.Enum;
using TechnicalStation.Core.Dto.Notification;

namespace TechnicalStation.Core.BLL.EventHandlers.Car
{
    public class CarAddedThenNotifyCarEventHandler : DomainEventHandlerBase<CarAdded>
    {

        private INotificationService notificationService;

        public CarAddedThenNotifyCarEventHandler(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public override async Task HandleAsync(CarAdded domainEvent)
        {
            NotificationInfo notificationInfo = new NotificationInfo()
            {
                NotificationType = NotificationType.CarAdded,
                AttachedObject = domainEvent
            };

            await this.notificationService.Notify(notificationInfo);
        }
    }
}
