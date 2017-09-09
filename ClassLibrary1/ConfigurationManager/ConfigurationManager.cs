using Newtonsoft.Json;
using System;
using System.IO;

namespace ConfigurationManager
{
    internal class ConfigurationManager : IConfigurationManager
    {
        private Configuration configuration;

        public ConfigurationManager(string jsonPath)
        {
            var jsonString = File.ReadAllText(jsonPath);
            configuration = JsonConvert.DeserializeObject<Configuration>(jsonString);
        }

        public Configuration Configuration => configuration;
    }
}