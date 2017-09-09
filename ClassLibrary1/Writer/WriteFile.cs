using System;
using System.IO;
using FileSystem.Tables;
using Newtonsoft.Json;

namespace Cooperativa.FileSystem
{
    public class WriteFile : IWriteFile
    {

        public WriteFile()
        {
            if (!File.Exists(@"C:\\cooperativa\\project.json"))
            {
                File.Create(@"C:\\cooperativa\\project.json");
            }
            if (!File.Exists(@"C:\\cooperativa\\budject.json"))
            {
                File.Create(@"C:\\cooperativa\\budject.json");
            }
            if (!File.Exists(@"C:\\cooperativa\\resource.json"))
            {
                File.Create(@"C:\\cooperativa\\resource.json");
            }
        }

        public void SaveProject(Project project)
        {
            System.IO.File.WriteAllText(@"C:\\project.json", JsonConvert.SerializeObject(project));
        }

        public void SaveBudjet(Project budject)
        {
            System.IO.File.WriteAllText(@"C:\\budject.json", JsonConvert.SerializeObject(budject));
        }
        public void SaveResource(Project resource)
        {
            System.IO.File.WriteAllText(@"C:\\resource.json", JsonConvert.SerializeObject(resource));
        }

        public void SaveStage(Project stage)
        {
            System.IO.File.WriteAllText(@"C:\\stage.json", JsonConvert.SerializeObject(stage));
        }
    }
}
