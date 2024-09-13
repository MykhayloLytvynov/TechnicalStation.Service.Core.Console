﻿using Common.Domain.Event;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechnicalStation.Core.BLL.Contract;
using TechnicalStation.Core.Domain.Customer;
using TechnicalStation.Core.Domain.Order;
using TechnicalStation.Core.Dto.Enum;
using TechnicalStation.Core.Dto.Notification;

namespace TechnicalStation.Core.BLL.EventHandlers.Order
{
    public class OrderAddedThenNotifyOrderEventHandler : DomainEventHandlerBase<OrderAdded>
    {
        private INotificationService notificationService;

        public OrderAddedThenNotifyOrderEventHandler(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public override async Task HandleAsync(OrderAdded domainEvent)
        {
            NotificationInfo notificationInfo = new NotificationInfo()
            {
                NotificationType = NotificationType.OrderAdded,
                AttachedObject = domainEvent
            };

            await this.notificationService.Notify(notificationInfo);
        }
    }
}
