using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalStation.Core.BLL
{
    using TechnicalStation.Core.DAL.Contract;
    using TechnicalStation.Core.BLL.Contract;

    public class ApplicationServiceFactory : IApplicationServiceFactory
    {
        readonly Dictionary<Type, Func<object>> collection = new Dictionary<Type, Func<object>>();
        private readonly IRepositoryFactory repositoryFactory;

        private EventHandlersConfigurator eventHandlersConfigurator;

        private object locker = new object();

        public ApplicationServiceFactory(IRepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;

            this.collection.Add(typeof(IUserService), () => new UserService());
            this.collection.Add(typeof(IWorkerService), () => new WorkerService(repositoryFactory.Create<IWorkerRepository>()));
            this.collection.Add(typeof(IWorkService), () => new WorkService(repositoryFactory.Create<IWorkRepository>()));
            this.collection.Add(typeof(IOrderService), () => new OrderService(repositoryFactory.Create<IOrderRepository>()));
            this.collection.Add(typeof(ICarService), () => new CarService(repositoryFactory.Create<ICarRepository>()));
            this.collection.Add(typeof(ICustomerService), () => new CustomerService(repositoryFactory.Create<ICustomerRepository>()));
            
        }

        public void ConfigureHandlers(INotificationService notificationService)
        {
            if (this.eventHandlersConfigurator == null)
            {
                lock (locker)
                {
                    eventHandlersConfigurator = new EventHandlersConfigurator();
                    eventHandlersConfigurator.Configure(notificationService);
                }
            }
        }

        public T Create<T>()
        {
            Type type = typeof(T);

            if (!this.collection.ContainsKey(type))
            {
                throw new MissingMemberException(type.ToString() + "is missing.");
            }

            return (T)this.collection[type]();
        }


    }
}
