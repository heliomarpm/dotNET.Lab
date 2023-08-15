using Microsoft.Data.Sqlite;
using Sample.CRUDSQLite.Repository;
using System;
using System.Data;

namespace Sample.CRUDSQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var conn = new SqliteConnection(@"Data Source=db.db"))
            {
                conn.Open();
                using (var comm = conn.CreateCommand())
                {
                    comm.CommandText = "SELECT ID, NomeArquivo FROM Arquivos";
                    var reader = comm.ExecuteReader();
                    var table = new DataTable();
                    table.Load(reader);
                    Console.WriteLine(table);
                }
            }


            string connectionString = "Data Source=:memory:";
            var databaseType = DbConnectionType.Sqlite;

            using (UserRepository userRepository = new(connectionString, databaseType))
            {
                Console.WriteLine("Creating user table\n");
                userRepository.CreateUserTable();

                Console.WriteLine("Inserting data to user table\n");
                userRepository.InsertIntoUserTable();

                Console.WriteLine("Selecting data\n");
                //userRepository.SelectFromUserTable();

                Console.WriteLine("\nGet User By ID: 1\n");
                var user = userRepository.GetUserdById(1);
                if (user != null)
                {
                    Console.WriteLine("User Name: {0}", user.Username);
                    Console.WriteLine("Email: {0}", user.Email);
                }

                Console.WriteLine("\nDeleting data\n");
                userRepository.DeleteFromUserTable();

                Console.WriteLine("Selecting data\n");
                //userRepository.SelectFromUserTable();

                Console.WriteLine("Inserting multiple data to user table\n");
                userRepository.InsertMultipleWithTransaction();

                Console.WriteLine("Selecting data\n");
                userRepository.SelectFromUserTable();
            }

            Console.ReadLine();
        }
    }
}
