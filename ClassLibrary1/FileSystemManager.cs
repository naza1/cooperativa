using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigurationManager;

namespace Cooperativa.FileSystem.FileSystemManager
{
    public class FileSystemManager
    {
        private static FileSystemManager _instance;

        private string _path;

        public FileSystemManager(IConfigurationManager configurationManager)
        {
            _path = configurationManager.Configuration.FileDirectory;
        }

        public static FileSystemManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FileSystemManager(new ConfigurationManager.ConfigurationManager("configuration.json"));
                }
                return _instance;
            }
        }
    }
}
