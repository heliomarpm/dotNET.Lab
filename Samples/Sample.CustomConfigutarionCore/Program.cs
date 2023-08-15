using System;
using System.Configuration;

namespace Sample.CustomConfigutarionCore
{
    class Program
    {
        static void Main(string[] args)
        {
            TestUrlsConfiguration();
            UsingCustomSectionCollection.CreateSection();
            //UsingCustomSectionCollection.AddSection();
            //UsingCustomSectionCollection.GetSection();
            //UsingCustomSectionCollection.GetEnumerator();
            //UsingCustomSectionCollection.GetAllKeys();
            //UsingCustomSectionCollection.GetKeys();
            //UsingCustomSectionCollection.GetItems();

            //UsingCustomSectionCollection.Remove();
            //UsingCustomSectionCollection.Clear();

            Console.WriteLine("Hello World!");
        }

        static void TestUrlsConfiguration()
        {
            // Get current configuration file.
            System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);

            // Get the MyUrls section.
            UrlsSection myUrlsSection =
                config.GetSection("MyUrls") as UrlsSection;

            if (myUrlsSection == null)
            {
                Console.WriteLine("Failed to load UrlsSection.");
            }
            else
            {
                Console.WriteLine("The 'simple' element of app.config:");
                Console.WriteLine("  Name={0} URL={1} Port={2}",
                    myUrlsSection.Simple.Name,
                    myUrlsSection.Simple.Url,
                    myUrlsSection.Simple.Port);

                Console.WriteLine("The urls collection of app.config:");
                for (int i = 0; i < myUrlsSection.Urls.Count; i++)
                {
                    Console.WriteLine("  Name={0} URL={1} Port={2}",
                        myUrlsSection.Urls[i].Name,
                        myUrlsSection.Urls[i].Url,
                        myUrlsSection.Urls[i].Port);
                }
            }
            Console.ReadLine();
        }
    }
}
