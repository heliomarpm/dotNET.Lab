using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Data.Common;

namespace Sample.CRUDSQLite
{
    public class ConnectionHelper
    {
        public static DbConnection GetDbConnection(string connectionString, DbConnectionType type)
        {
            return type switch
            {
                DbConnectionType.Sqlite => new SqliteConnection(connectionString),
                _ => null,
            };
        }

        /// <summary>
        /// Método que trata o valor que retornou do banco de dados;
        /// </summary>
        /// <typeparam name="T">Tipo do campo</typeparam>
        /// <param name="reader">Ponteiro do registro</param>
        /// <param name="fieldName">Nome do campo</param>
        /// <returns>Valor do campo</returns>
        public static T GetValue<T>(IDataReader reader, string fieldName)
        {
            if (reader.IsDBNull(reader.GetOrdinal(fieldName)).Equals(true))
                return default;
            else
                return (T)Convert.ChangeType(reader.GetValue(reader.GetOrdinal(fieldName)), typeof(T));
        }
    }
}
