using System;
using System.Configuration;

namespace Sample.CustomConfigutarionCore
{
    // Define a custom section programmatically.
    public sealed class CustomSection : ConfigurationSection
    {
        // The collection (property bag) that contains 
        // the section properties.
        private static ConfigurationPropertyCollection _Properties;

        // The FileName property.
        private static readonly ConfigurationProperty _FileName =
            new("fileName", typeof(string), "default.txt", ConfigurationPropertyOptions.IsRequired);

        // The MasUsers property.
        private static readonly ConfigurationProperty _MaxUsers =
            new("maxUsers", typeof(long), (long)1000, ConfigurationPropertyOptions.None);

        // The MaxIdleTime property.
        private static readonly ConfigurationProperty _MaxIdleTime =
            new("maxIdleTime", typeof(TimeSpan), TimeSpan.FromMinutes(5), ConfigurationPropertyOptions.IsRequired);

        // CustomSection constructor.
        public CustomSection()
        {
            // Property initialization
            _Properties = new ConfigurationPropertyCollection
            {
                _FileName,
                _MaxUsers,
                _MaxIdleTime
            };
        }

        // This is a key customization. 
        // It returns the initialized property bag.
        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                return _Properties;
            }
        }

        [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 60)]
        public string FileName
        {
            get { return (string)this["fileName"]; }
            set { this["fileName"] = value; }
        }

        [LongValidator(MinValue = 1, MaxValue = 1000000, ExcludeRange = false)]
        public long MaxUsers
        {
            get { return (long)this["maxUsers"]; }
            set { this["maxUsers"] = value; }
        }

        [TimeSpanValidator(MinValueString = "0:0:30", MaxValueString = "5:00:0", ExcludeRange = false)]
        public TimeSpan MaxIdleTime
        {
            get { return (TimeSpan)this["maxIdleTime"]; }
            set { this["maxIdleTime"] = value; }
        }
    }

}
