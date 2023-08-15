using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Sample.CRUDSQLite.Repository
{
    public class UserRepository : IDisposable
    {
        DbConnection connection;
        DbConnectionType databaseType;

        public UserRepository(string connectionString, DbConnectionType dbType)
        {
            this.databaseType = dbType;
            this.connection = ConnectionHelper.GetDbConnection(connectionString, dbType);
        }
        private void OpenConnection()
        {
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();
        }
        private void CloseConnection()
        {
            if (connection.State != System.Data.ConnectionState.Closed)
                connection.Close();
        }

        public void CreateUserTable()
        {
            OpenConnection();

            string commandText = @"
                        CREATE TABLE IF NOT EXISTS Users (
                            [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                            [Username] NVARCHAR(64) NOT NULL,
                            [Email] NVARCHAR(128) NOT NULL,
                            [Password] NVARCHAR(128) NOT NULL
                        )";

            // Create table if not exist
            connection.ExecuteNonQuery(commandText);
        }

        public void SelectFromUserTable()
        {
            OpenConnection();

            using var result = (DbDataReader)connection.ExecuteReader("SELECT UserName, Email from Users;");
            if (result.HasRows)
                while (result.Read())
                {
                    Console.WriteLine(string.Format("UserName: {0}", result.GetString(0)));
                    Console.WriteLine(string.Format("Email: {0}", result.GetString(1)));
                }

        }

        public void InsertIntoUserTable()
        {
            OpenConnection();

            string commandText = @"
                        INSERT INTO Users
                            (Username, Email, Password)
                        VALUES
                            ('admin', 'testing@gmail.com', 'test')";

            connection.ExecuteNonQuery(commandText);
        }

        public void DeleteFromUserTable()
        {
            OpenConnection();
            connection.ExecuteNonQuery("DELETE FROM Users");
        }

        // Transaction Demo
        public void InsertMultipleWithTransaction()
        {
            OpenConnection();
            using var transaction = connection.BeginTransaction();
            try
            {
                connection.ExecuteNonQuery(@"INSERT INTO Users(Username, Email, Password) VALUES('admin1', 'testing1@gmail.com', 'test1')");
                connection.ExecuteNonQuery(@"INSERT INTO Users(Username, Email, Password) VALUES('admin2', 'testing2@gmail.com', 'test2')");
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                transaction.Rollback();
            }
        }

        // Parameter Demo
        public User GetUserdById(int userId)
        {
            try
            {
                var parameters = new List<IDataParameter>
                {
                    ParameterHelper.GetParameter("@UserId", userId, databaseType)
                };

                using var result = (DbDataReader)connection.ExecuteReader("SELECT * From Users WHERE Id = @UserId;", CommandType.Text, parameters);
                if (result.Read())
                {
                    var user = new User
                    {
                        Id = result.GetInt32(0),
                        Username = result.GetString(1),
                        Email = result.GetString(2),
                        Password = result.GetString(3)
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        public void Dispose()
        {
            CloseConnection();
        }
    }
}
