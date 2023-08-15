using Sample.CRUDSQLiteEFCore.Database;
using Sample.CRUDSQLiteEFCore.Model;
using System;
using System.IO;
using System.Linq;

namespace Sample.CRUDSQLiteEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //string dbName = "app.db";
            //if (File.Exists(dbName))
            //{
            //    File.Delete(dbName);
            //}

            using (var dbContext = new MyDbContext())
            {
                string dbName = "app.s3";
                if (!File.Exists(dbName))
                {
                    //Ensure database is created
                    dbContext.Database.EnsureCreated();
                }

                if (!dbContext.Blogs.Any())
                {
                    dbContext.Blogs.AddRange(new Blog[]
                        {
                             new Blog{ BlogId=1, Title="Blog 1", SubTitle="eu sou linda " },
                             new Blog{ BlogId=2, Title="Blog 2", SubTitle="Blog 2 subtitle" },
                             new Blog{ BlogId=3, Title="Blog 3", SubTitle="Blog 3 subtitle" }
                        });
                    dbContext.SaveChanges();
                }

                foreach (var blog in dbContext.Blogs)
                {
                    Console.WriteLine($"BlogID={blog.BlogId}\tTitle={blog.Title}\t{blog.SubTitle}\tDateTimeAdd={blog.DateTimeAdd}");
                }
            }
            Console.ReadLine();
        }
    }

}
