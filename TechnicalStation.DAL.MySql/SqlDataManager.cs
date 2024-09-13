using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TechnicalStation.Core.DAL.Contract;

namespace TechnicalStation.DAL.MySql
{
    public partial class SqlDataManager : ISqlDataManager
    {
        /// <summary>
        /// The connection string.
        /// </summary>
        protected string connectionString = string.Empty;

        public SqlDataManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected virtual List<T> ProcessRead<T>(IDataReader reader)
        {
            List<T> collection = new List<T>();
            
            while (reader.Read())
            {
               T element = this.Process<T>(reader);
                collection.Add((T) element);
            }

            return collection;
        }

        protected virtual T Process<T>(IDataReader reader)
        {            
            Type type = typeof(T);
            PropertyInfo[] p = type.GetProperties();
            T element = (T)Activator.CreateInstance(type);

            foreach (PropertyInfo pi in p)
            {
                try
                {
                    if (reader[pi.Name.ToLower()] != System.DBNull.Value)
                    {
                        pi.SetValue(element, reader[pi.Name], null);
                    }
                }
                catch (System.IndexOutOfRangeException) { }
            }

            return element;
        }

        
        public void AddParameter(IDbCommand sqlCommand, string parameterName, object value, ParameterDirection direction = ParameterDirection.Input)
        {
            ((MySqlCommand)sqlCommand).Parameters.AddWithValue(parameterName, value).Direction = direction;
        }

        public object GetValue(IDbCommand sqlCommand, string parameterName)
        {
            return ((MySqlCommand) sqlCommand).Parameters[parameterName].Value;
        }
    }
}
