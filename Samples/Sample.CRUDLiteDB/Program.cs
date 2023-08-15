using LiteDB;
using System;
using System.Linq;

namespace Sample.CRUDLiteDB
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Phones { get; set; }
        public bool IsActive { get; set; }
    }

    class Program
    {
        /// Site Oficial: 
        ///         https://www.litedb.org/docs/getting-started/
        /// Exemplos: 
        ///         https://csharp.hotexamples.com/examples/LiteDB/LiteDatabase/-/php-litedatabase-class-examples.html
        ///         https://csharp.hotexamples.com/examples/LiteDB/Query/-/php-query-class-examples.html

        static void Main(string[] args)
        {
            string connectionString = @"app.db";

            // Open database (or create if not exits)
            using (var db = new LiteDatabase(connectionString))
            {
                // Get user collection
                var users = db.GetCollection<User>("users");
                // Create your new user instance
                var user = new User
                {
                    Name = "Heliomar",
                    Email = "heliomarpm@gmail.com"
                };
                // Insert new user document (Id will be auto-incremented)
                users.Insert(user);

                var result = users.Find(x => x.Email == "Heliomarpm@gmail.com").FirstOrDefault();
                Console.WriteLine(result.Name);

                // Update a document inside a collection
                user.Name = "Heliomar Marques";
                users.Update(user);
                // Index document using a document property
                users.EnsureIndex(x => x.Name);
                Console.WriteLine(users.FindOne(x => x.Name == "Heliomar Marques").Name);

                foreach (var item in users.FindAll().ToList())
                {
                    Console.WriteLine("{0} - {1} - {2}", item.Id, item.Name, item.Email);
                }

                users.DeleteAll();
            }

            // outra forma de usar operacoes CRUD
            using (var db = new LiteRepository(connectionString))
            {
                // vai criar automaticamente um tabela User
                db.Insert(new User
                {
                    Name = "Angelina",
                    Email = "angelina@gmail.com"
                });
            }

            // Trabalhando com arquivos 
            using (var db = new LiteDatabase(connectionString))
            {
                db.FileStorage.Upload("Avatar", @"avatar.png"); //Uploads a file to the database

                db.FileStorage.Download("Avatar", @"d:\useravatar.jpg", true);

                var file = db.FileStorage.FindById("Avatar");
                file.SaveAs(@"d:\save-avatar.png", true);

            }
            // ou
            using (var db = new LiteDatabase(connectionString))
            {
                var storage = db.GetStorage<int>();

                // Upload a file from file system to database
                storage.Upload(123, @"avatar.png");

                // And download later
                storage.Download(123, @"copy-avatar.png", true);
            }

            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(@"MyData.db"))
            {
                // Get a collection (or create, if doesn't exist)
                var col = db.GetCollection<Customer>("customers");

                // Create your new customer instance
                var customer = new Customer
                {
                    Name = "John Doe",
                    Phones = new string[] { "8000-0000", "9000-0000" },
                    IsActive = true
                };

                // Insert new customer document (Id will be auto-incremented)
                col.Insert(customer);

                // Update a document inside a collection
                customer.Name = "Jane Doe";

                col.Update(customer);

                // Index document using document Name property
                col.EnsureIndex(x => x.Name);

                // Use LINQ to query documents (filter, sort, transform)
                var results = col.Query()
                    .Where(x => x.Name.StartsWith("J"))
                    .OrderBy(x => x.Name)
                    .Select(x => new { x.Name, NameUpper = x.Name.ToUpper() })
                    .Limit(10)
                    .ToList();

                // Let's create an index in phone numbers (using expression). It's a multikey index
                col.EnsureIndex(x => x.Phones);

                // and now we can query phones
                var r = col.FindOne(x => x.Phones.Contains("8888-5555"));


                foreach (var item in col.FindAll().ToList())
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
    }
}
