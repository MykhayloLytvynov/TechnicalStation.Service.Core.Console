using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalStation.Core.BLL
{
    using Common.Domain;

    using TechnicalStation.Core.BLL.Contract;
    using TechnicalStation.Core.BLL.Contract;
    using TechnicalStation.Core.BLL.EventHandlers.Car;
    using TechnicalStation.Core.BLL.EventHandlers.Customer;
    using TechnicalStation.Core.BLL.EventHandlers.Order;
    using TechnicalStation.Core.BLL.EventHandlers.Work;
    using TechnicalStation.Core.BLL.EventHandlers.Worker;

    public class EventHandlersConfigurator
    {
        public void Configure(INotificationService notitifactionService)
        {
            Dispatcher.Instance.Register(new OrderDeletedThenNotifyOrderEventHandler(notitifactionService));
            Dispatcher.Instance.Register(new OrderUpdatedThenNotifyOrderEventHandler(notitifactionService));
            Dispatcher.Instance.Register(new OrderAddedThenNotifyOrderEventHandler(notitifactionService));

            Dispatcher.Instance.Register(new CustomerDeletedThenNotifyCustomerEventHandler(notitifactionService));
            Dispatcher.Instance.Register(new CustomerUpdatedThenNotifyCustomerEventHandler(notitifactionService));
            Dispatcher.Instance.Register(new CustomerAddedThenNotifyCustomerEventHandler(notitifactionService));

            Dispatcher.Instance.Register(new CarDeletedThenNotifyCarEventHandler(notitifactionService));
            Dispatcher.Instance.Register(new CarUpdatedThenNotifyCarEventHandler(notitifactionService));
            Dispatcher.Instance.Register(new CarAddedThenNotifyCarEventHandler(notitifactionService));

            Dispatcher.Instance.Register(new WorkDeletedThenNotifyWorkEventHandler(notitifactionService));
            Dispatcher.Instance.Register(new WorkUpdatedThenNotifyWorkEventHandler(notitifactionService));
            Dispatcher.Instance.Register(new WorkAddedThenNotifyWorkEventHandler(notitifactionService));

            Dispatcher.Instance.Register(new WorkerDeletedThenNotifyWorkerEventHandler(notitifactionService));
            Dispatcher.Instance.Register(new WorkerUpdatedThenNotifyWorkerEventHandler(notitifactionService));
            Dispatcher.Instance.Register(new WorkerAddedThenNotifyWorkerEventHandler(notitifactionService));

            //Dispatcher.Instance.Register(new PasswordChangedThenNotifyUserEventHandler(notitifactionService));
            //Dispatcher.Instance.Register(new UserEnteredTheSystemThenSubscribeUserNotificationsEventHandler(notitifactionService));
        }
    }
}
