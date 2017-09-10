using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Reader
{
    public class ReadFile
    {
        public ReadFile()
        {
            
        }
        public string ReadProject()
        {
            if (File.Exists(@"C:\\cooperativa\\project.json"))
            {
                return File.ReadAllText(@"C:\\cooperativa\\project.json");
            }
            return string.Empty;
        }

    }
}
