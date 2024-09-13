﻿using Common.Domain.Event;
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
    public class WorkAddedThenNotifyWorkEventHandler : DomainEventHandlerBase<WorkAdded>
    {
        private INotificationService notificationService;

        public WorkAddedThenNotifyWorkEventHandler(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public override async Task HandleAsync(WorkAdded domainEvent)
        {
            NotificationInfo notificationInfo = new NotificationInfo()
            {
                NotificationType = NotificationType.WorkerAdded,
                AttachedObject = domainEvent
            };

            await this.notificationService.Notify(notificationInfo);
        }
    }
}
