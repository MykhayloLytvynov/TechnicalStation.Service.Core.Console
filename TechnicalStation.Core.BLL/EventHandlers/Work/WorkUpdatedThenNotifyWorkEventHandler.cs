using Common.Domain.Event;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechnicalStation.Core.BLL.Contract;
using TechnicalStation.Core.Domain.Order;
using TechnicalStation.Core.Domain.Work;
using TechnicalStation.Core.Dto.Enum;
using TechnicalStation.Core.Dto.Notification;

namespace TechnicalStation.Core.BLL.EventHandlers.Work
{
    public class WorkUpdatedThenNotifyWorkEventHandler : DomainEventHandlerBase<WorkUpdated>
    {
        private INotificationService notificationService;

        public WorkUpdatedThenNotifyWorkEventHandler(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public override async Task HandleAsync(WorkUpdated domainEvent)
        {
            NotificationInfo notificationInfo = new NotificationInfo()
            {
                NotificationType = NotificationType.WorkUpdated,
                AttachedObject = domainEvent
            };

            await this.notificationService.Notify(notificationInfo);
        }
    }
}
