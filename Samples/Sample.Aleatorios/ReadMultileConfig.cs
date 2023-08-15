using System;
using System.Configuration;

namespace Sample.Aleatorios
{
    /// <summary>
    /// como ler vários arquivos de configuração em tempo de execução.
    /// </summary>
    public class ReadMultileConfig
    {
        static void Run()
        {
            var configFile = new ExeConfigurationFileMap();
            configFile.ExeConfigFilename = "MyConfig.config";

            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);
            KeyValueConfigurationCollection settings = config.AppSettings.Settings;

            string fName = ConfigurationManager.AppSettings["FirstName"];
            string lName = settings["LastName"].Value;
            string country = settings["Country"].Value;

            Console.WriteLine($"{fName} {lName} \nCountry {country}");

        }

    }
}
