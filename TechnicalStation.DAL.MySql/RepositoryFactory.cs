using System;
using System.Collections.Generic;
using TechnicalStation.Core.DAL.Contract;

namespace TechnicalStation.DAL.MySql
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private ISqlDataManager sqlDataManager;

        private Dictionary<Type, object> collection = new Dictionary<Type, object>();

        public RepositoryFactory(ISqlDataManager sqlDataManager)
        {
            this.sqlDataManager = sqlDataManager;

            this.ConfigureRepositoryCollection();
        }

        protected void ConfigureRepositoryCollection()
        {
            // Extension point
            this.collection.Add(typeof(IOrderRepository), new OrderRepository(this.sqlDataManager));
            this.collection.Add(typeof(IWorkRepository), new WorkRepository(this.sqlDataManager));
            this.collection.Add(typeof(ICustomerRepository), new CustomerRepository(this.sqlDataManager));
            this.collection.Add(typeof(ICarRepository), new CarRepository(this.sqlDataManager));
            this.collection.Add(typeof(IWorkerRepository), new WorkerRepository(this.sqlDataManager));
        }

        public T Create<T>()
        {
            Type type = typeof(T);

            if (!this.collection.ContainsKey(type))
            {
                throw new MissingMemberException(type.ToString() + "is missing in the collection");
            }

            return (T)this.collection[type];
        }
    }
}
