using Common.Domain.Event;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechnicalStation.Core.BLL.Contract;
using TechnicalStation.Core.Domain.Work;
using TechnicalStation.Core.Domain.Worker;
using TechnicalStation.Core.Dto.Enum;
using TechnicalStation.Core.Dto.Notification;

namespace TechnicalStation.Core.BLL.EventHandlers.Worker
{
    public class WorkerUpdatedThenNotifyWorkerEventHandler : DomainEventHandlerBase<WorkerUpdated>
    {
        private INotificationService notificationService;

        public WorkerUpdatedThenNotifyWorkerEventHandler(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public override async Task HandleAsync(WorkerUpdated domainEvent)
        {
            NotificationInfo notificationInfo = new NotificationInfo()
            {
                NotificationType = NotificationType.WorkerUpdated,
                AttachedObject = domainEvent
            };

            await this.notificationService.Notify(notificationInfo);
        }
    }
}
