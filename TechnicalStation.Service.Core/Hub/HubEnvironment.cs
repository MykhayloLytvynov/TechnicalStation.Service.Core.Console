using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.SignalR;
using TechnicalStation.Core.BLL.Contract;
using TechnicalStation.Service.Core.Controller;
using TechnicalStation.Service.Core.Hub;

namespace TechnicalStation.Service.Hub
{

    public class HubEnvironment
    {

		public IUserService userService;
		public ICarService carService;
		public IOrderService orderService;
		public IWorkService workService;
		public IWorkerService workerService;
		public ICustomerService customerService;

		public HubEnvironment(IHubContext<MainHub> hubContext, IApplicationServiceFactory serviceFactory)
		{
			serviceFactory.ConfigureHandlers(new NotificationService(hubContext));
			this.userService = serviceFactory.Create<IUserService>();
            this.carService = serviceFactory.Create<ICarService>();
			this.orderService = serviceFactory.Create<IOrderService>();
			this.workService = serviceFactory.Create<IWorkService>();
			this.workerService = serviceFactory.Create<IWorkerService>();
			this.customerService = serviceFactory.Create<ICustomerService>();

        }
    }
}
