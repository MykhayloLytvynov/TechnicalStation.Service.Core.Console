using System;
using System.Collections.Generic;
using System.Text;
using TechnicalStation.Core.BLL;
using TechnicalStation.Core.BLL.Contract;
using TechnicalStation.Core.DAL.Contract;
using TechnicalStation.DAL.MySql;

namespace TechnicalStation.Core.BLL.IntegrationTest.Context
{
    public class TestingContext
    {
        /// <summary>
        /// The dal manager factory.
        /// </summary>
        private static IRepositoryFactory repositoryFactory;

        private static IApplicationServiceFactory applicationServiceFactory;

        private static NotificationService notificationService;

        static TestingContext()
        {

            string connectionString = ConnectionStringReader.GetConnectionString(databaseName: "Orders", xmlFilePath: "Configuration/connectionStrings.config");
            ISqlDataManager sqlDataManager = new SqlDataManager(connectionString);
            repositoryFactory = new RepositoryFactory(sqlDataManager);
            applicationServiceFactory = new ApplicationServiceFactory(repositoryFactory);
            notificationService = new NotificationService();
            applicationServiceFactory.ConfigureHandlers(notificationService);
        }

        /// <summary>
        /// The get dal manager factory.
        /// </summary>
        /// <returns>
        /// The <see cref="IDalManagerFactory"/>.
        /// </returns>
        //public static T GetRepository<T>()
        //{
        //    return repositoryFactory.Create<T>();
        //}

        public static T GetService<T>()
        {
            return applicationServiceFactory.Create<T>();
        }

    }
}
