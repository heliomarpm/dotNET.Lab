using System;
using System.Collections;
using System.Configuration;

namespace Sample.CustomConfigutarionCore
{
    public class UsingCustomSectionCollection
    {
        // Create a custom section.
        public static void CreateSection()
        {
            try
            {
                // Get the current configuration file.
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // Create the section entry  
                // in the <configSections> and the 
                // related target section in <configuration>.
                if (config.Sections["CustomSection"] == null)
                {
                    var customSection = new CustomSection();
                    config.Sections.Add("CustomSection", customSection);
                    customSection.SectionInformation.ForceSave = true;
                    config.Save(ConfigurationSaveMode.Full);
                }

            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }

        public static void GetAllKeys()
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                ConfigurationSectionCollection sections = config.Sections;

                foreach (string key in sections.Keys)
                {
                    Console.WriteLine("Key value: {0}", key);
                }
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }

        public static void Clear()
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.Sections.Clear();
                config.Save(ConfigurationSaveMode.Full);
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }

        public static void GetSection()
        {
            try
            {
                if (ConfigurationManager.GetSection("CustomSection") is not CustomSection customSection)
                    Console.WriteLine("Failed to load CustomSection.");
                else
                {
                    // Display section information
                    Console.WriteLine("Defaults:");
                    Console.WriteLine("File Name:       {0}", customSection.FileName);
                    Console.WriteLine("Max Users:       {0}", customSection.MaxUsers);
                    Console.WriteLine("Max Idle Time:   {0}", customSection.MaxIdleTime);
                }
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }

        public static void GetEnumerator()
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                ConfigurationSectionCollection sections = config.Sections;

                IEnumerator secEnum = sections.GetEnumerator();

                int i = 0;
                while (secEnum.MoveNext())
                {
                    string setionName = sections.GetKey(i);
                    Console.WriteLine("Section name: {0}", setionName);
                    i += 1;
                }
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }

        public static void GetKeys()
        {

            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                ConfigurationSectionCollection sections = config.Sections;

                foreach (string key in sections.Keys)
                {
                    Console.WriteLine("Key value: {0}", key);
                }
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }

        public static void GetItems()
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                ConfigurationSectionCollection sections = config.Sections;

                ConfigurationSection section1 = sections["runtime"];

                ConfigurationSection section2 = sections[0];

                Console.WriteLine("Section1: {0}", section1.SectionInformation.Name);
                Console.WriteLine("Section2: {0}", section2.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }

        public static void Remove()
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                CustomSection customSection = config.GetSection("CustomSection") as CustomSection;

                if (customSection != null)
                {
                    config.Sections.Remove("CustomSection");
                    customSection.SectionInformation.ForceSave = true;
                    config.Save(ConfigurationSaveMode.Full);
                }
                else
                    Console.WriteLine("CustomSection does not exists.");
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }

        public static void AddSection()
        {

            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                CustomSection customSection = new();

                string index = config.Sections.Count.ToString();

                customSection.FileName = "newFile" + index + ".txt";

                string sectionName = "CustomSection" + index;

                TimeSpan ts = new TimeSpan(0, 15, 0);
                customSection.MaxIdleTime = ts;
                customSection.MaxUsers = 100;

                config.Sections.Add(sectionName, customSection);
                customSection.SectionInformation.ForceSave = true;
                config.Save(ConfigurationSaveMode.Full);
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }

    }
}
