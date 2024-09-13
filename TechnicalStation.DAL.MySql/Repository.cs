using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Common.Domain;
using TechnicalStation.Core.DAL.Contract;

namespace TechnicalStation.DAL.MySql
{
    /// <summary>
    /// The dal manager base.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public abstract class Repository<T> : IRepository<T> where T : Identifiable
    {
        /// <summary>
        /// Sql helper from Common.DAL.Sql library. More flexible solution needs TypeController.Instance.GetObjectOfType<ISqlDataManager>() resolution.
        /// </summary>
        protected ISqlDataManager sqlDataManager;

        /// <summary>
        /// Contains the connection string.
        /// </summary>
        protected string connectionString = string.Empty;

        /// <summary>
        /// The concept name.
        /// </summary>
        protected string conceptName;

        public Repository(ISqlDataManager sqlDataManager)
        {
            this.sqlDataManager = sqlDataManager;
            this.conceptName = typeof(T).Name ;
        }


        public async Task<T> GetByIdAsync(int id)
        {
            string queryCommand = string.Format("Get{0}ById", this.conceptName);

            return await this.sqlDataManager.GetByIdAsync<T>(queryCommand, id);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        public async virtual Task UpdateAsync(T element)
        {
            // Define the procedure.
            string queryCommand = string.Format("Update{0}", this.conceptName);
            IDbCommand sqlCommand = this.sqlDataManager.GetCommand(queryCommand);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Set the parameters.
            this.sqlDataManager.AddParameter(sqlCommand, @"Id", element.Id);
            this.AddInputParameterCollection(sqlCommand, element);

            // Execute the procedure.
            await this.sqlDataManager.ExecuteCommandAsync(sqlCommand);
        }

        public virtual async Task AddAsync(T element)
        {
            // Define the procedure.
            string queryCommand = string.Format("Add{0}", this.conceptName);
            
            IDbCommand sqlCommand = this.sqlDataManager.GetCommand(queryCommand);
            //Console.WriteLine("addOrderMethod");
            //Console.WriteLine(sqlCommand);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            
            // Set the parameters.
            this.AddInputParameterCollection(sqlCommand, element);
            this.sqlDataManager.AddParameter(sqlCommand, @"Id", 4, ParameterDirection.Output);
            // Execute procedure.
            await this.sqlDataManager.ExecuteCommandAsync(sqlCommand);
            
            // The result is id of the object just added.
            int id = Convert.ToInt32(this.sqlDataManager.GetValue(sqlCommand, "@Id"));
            //Console.WriteLine("dsfdsfsdfsdf");
            // Set the object's unique identifier.
            element.Id = id;
        }

        protected abstract void AddInputParameterCollection(IDbCommand sqlCommand, T element);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public async Task DeleteAsync(int id)
        {
            // Define the procedure.
            string commandText = string.Format("Delete{0}", this.conceptName);
            IDbCommand sqlCommand = this.sqlDataManager.GetCommand(commandText);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Define the parameters.
            this.sqlDataManager.AddParameter(sqlCommand, @"Id", id);

            // Execute the procedure.
            await this.sqlDataManager.ExecuteCommandAsync(sqlCommand);
        }
        
        /// <summary>
        /// The get collection.
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
        public async virtual Task<List<T>> GetCollectionAsync()
        {
            // todo: Think about Provider naming.
            string queryCommand = $"select * from `{this.conceptName}`";

            return await this.sqlDataManager.DoQueryAsync<T>(queryCommand);
        }

        public async Task ClearAsync()
        {
            // todo: Think about Provider naming.
            string commandText = string.Format("delete from `{0}`", this.conceptName);
            IDbCommand sqlCommand = this.sqlDataManager.GetCommand(commandText);
            await this.sqlDataManager.ExecuteCommandAsync(sqlCommand);
        }
    }
}
