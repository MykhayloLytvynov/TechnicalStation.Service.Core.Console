using TechnicalStation.Core.DAL.Contract;
using TechnicalStation.DAL.MySql;

namespace TechnicalStation.DAL.Test.Base
{
    /// <summary>
    /// The testing context.
    /// </summary>
    public class TestingContext
    {
        /// <summary>
        /// The dal manager factory.
        /// </summary>
        private static IRepositoryFactory repositoryFactory;

        static TestingContext()
        {

            string connectionString =
                ConnectionStringReader.GetConnectionString(databaseName:"Orders", xmlFilePath:"Configuration/connectionStrings.config");
            ISqlDataManager sqlDataManager = new SqlDataManager(connectionString);
            repositoryFactory = new RepositoryFactory(sqlDataManager);
            //unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
        }

        /// <summary>
        /// The get dal manager factory.
        /// </summary>
        /// <returns>
        /// The <see cref="IDalManagerFactory"/>.
        /// </returns>
        public static T GetRepository<T>()
        {
            return repositoryFactory.Create<T>();
        }
    }
}
