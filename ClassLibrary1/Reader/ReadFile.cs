using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSystem.Tables;
using ClassLibrary1.Db;

namespace ClassLibrary1.Reader
{
    public class ReadFile
    {
        public ReadFile(){}

        public string ReadProject()
        {
            if (File.Exists(@"C:\\cooperativa\\project.json"))
            {
                return File.ReadAllText(@"C:\\cooperativa\\project.json");
            }
            return string.Empty;
        }

        public List<Project> GetProjects()
        {
            var mongo = new MongoConection();

            return mongo.GetProjects().ToList();
        }

    }
}
