using Microsoft.Data.Sqlite;
using System.Data;

namespace Sample.CRUDSQLite
{
    public class ParameterHelper
    {
        public static IDataParameter GetParameter(string name, object value, DbConnectionType type)
        {
            return type switch
            {
                DbConnectionType.Sqlite => new SqliteParameter { ParameterName = name, Value = value },
                _ => null,
            };
        }
    }
}
