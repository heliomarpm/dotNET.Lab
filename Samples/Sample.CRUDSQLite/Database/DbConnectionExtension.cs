using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Sample.CRUDSQLite
{
    public enum DbConnectionType
    {
        Sqlite
    }

    public static class DbConnectionExtension
    {
        private static DbCommand CreateCommand(DbConnection connection, string commandText, CommandType commandType, List<IDataParameter> parameters = null, int timeout = -1)
        {
            var cmd = connection.CreateCommand();

            cmd.CommandText = commandText;
            cmd.CommandType = commandType;

            cmd.CommandTimeout = timeout > -1 ? timeout : connection.ConnectionTimeout;

            if (parameters != null && parameters.Count > 0)
                cmd.Parameters.AddRange(parameters.ToArray());

            return cmd;
        }

        public static int ExecuteNonQuery(this DbConnection connection, string commandText)
            => ExecuteNonQuery(connection, commandText, CommandType.Text);

        public static int ExecuteNonQuery(this DbConnection connection, string commandText, CommandType commandType, List<IDataParameter> parameters = null, int timeout = -1)
        {
            using var cmd = CreateCommand(connection, commandText, commandType, parameters, timeout);
            return cmd.ExecuteNonQuery();
        }

        public static T ExecuteScalar<T>(this DbConnection connection, string commandText)
            => (T)ExecuteScalar(connection, commandText, CommandType.Text);

        public static T ExecuteScalar<T>(this DbConnection connection, string commandText, CommandType commandType, List<IDataParameter> parameters = null, int timeout = -1)
            => (T)ExecuteScalar(connection, commandText, commandType, parameters, timeout);

        public static object ExecuteScalar(this DbConnection connection, string commandText)
            => ExecuteScalar(connection, commandText, CommandType.Text);

        public static object ExecuteScalar(this DbConnection connection, string commandText, CommandType commandType, List<IDataParameter> parameters = null, int timeout = -1)
        {
            using var cmd = CreateCommand(connection, commandText, commandType, parameters, timeout);
            return cmd.ExecuteScalar();
        }

        public static IDataReader ExecuteReader(this DbConnection connection, string commandText) =>
            ExecuteReader(connection, commandText, CommandType.Text);

        public static IDataReader ExecuteReader(this DbConnection connection, string commandText, CommandType commandType, List<IDataParameter> parameters = null, int timeout = -1)
        {
            using var cmd = CreateCommand(connection, commandText, commandType, parameters, timeout);
            return cmd.ExecuteReader();
        }
    }
}
