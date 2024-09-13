using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TechnicalStation.DAL.MySql
{
    partial class SqlDataManager
    {
        public IDbCommand GetCommand(string commandText)
        {
            return new MySqlCommand(commandText);
        }

        /// <summary>
        /// The get data table.
        /// </summary>
        /// <param name="tableName">
        /// The table name.
        /// </param>
        /// <returns>
        /// The <see cref="DataTable"/>.
        /// </returns>
        public async Task<List<T>> GetCollectionAsync<T>(string tableName)
        {
            try
            {
                string queryText = "select * from " + tableName;

                return await this.DoQueryAsync<T>(queryText);
            }
            catch (Exception ex)
            {
                string message = $"Get data table failed. Table:{tableName}";
                throw new Exception(message, ex);
            }
        }

        public async Task<T> GetByIdAsync<T>(string query, int id)
        {
            MySqlCommand command = new MySqlCommand(query);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("Id", id);
            command.Parameters[0].Direction = ParameterDirection.Input;

            List<T> collection = await this.ExecuteReaderAsync<T>(command);

            if (collection.Count == 0)
            {
                string nameOfType = typeof(T).Name;
                string message = string.Format($"Element {id} of type {nameOfType} is not found");
                throw new Exception(message);
            }
            else
            {
                return collection[0];
            }
        }

        public async Task ExecuteCommandAsync(IDbCommand command)
        {
            try
            {
                    using (MySqlConnection connection = new MySqlConnection(this.connectionString))
                    {
                        connection.Open();
                        command.Connection = connection;
                        int numberOfRows = await ((MySqlCommand)command).ExecuteNonQueryAsync();
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<T>> ExecuteReaderAsync<T>(IDbCommand command)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                connection.Open();
                command.Connection = connection;
                using (var reader = await ((MySqlCommand)command).ExecuteReaderAsync())
                {
                    return reader.Select(r => this.Process<T>(r)).ToList();
                }
            }
        }
        public async Task<List<T>> DoQueryAsync<T>(string query)
        {
            IDbCommand command = new MySqlCommand(query);

            List<T> collection = await this.ExecuteReaderAsync<T>(command);

            return collection;
        }

        public List<T> DoQuery<T>(string query, Dictionary<string, object> parameterCollection)
        {
            try
            {
                List<T> collection = new List<T>();

                using (MySqlConnection connection = new MySqlConnection(this.connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    foreach (KeyValuePair<string, object> kvp in parameterCollection)
                    {
                        command.Parameters.AddWithValue(kvp.Key, kvp.Value);
                    }

                    MySqlDataReader reader = command.ExecuteReader();

                    collection = this.ProcessRead<T>(reader);
                }

                return collection;
            }
            catch (Exception ex)
            {
                string message = $"Get data table failed. Connection:{this.connectionString} Table:{query}";
                throw new Exception(message, ex);
            }
        }

        public async Task<List<T>> DoQueryAsync<T>(string query, Dictionary<string, object> parameterCollection)
        {
            try
            {
                List<T> collection = new List<T>();

                using (MySqlConnection connection = new MySqlConnection(this.connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    foreach (KeyValuePair<string, object> kvp in parameterCollection)
                    {
                        command.Parameters.AddWithValue(kvp.Key, kvp.Value);
                    }

                    collection = await this.ExecuteReaderAsync<T>(command);
                }

                return collection;
            }
            catch (Exception ex)
            {
                string message = $"Get data table failed. Connection:{this.connectionString} Table:{query}";
                throw new Exception(message, ex);
            }
        }
    }
}
