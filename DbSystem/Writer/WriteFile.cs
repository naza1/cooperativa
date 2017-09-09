using DbSystem.Tables;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace Cooperativa.DbSystem
{
    public class WriteFile : IWriteFile
    {

        public WriteFile()
        {
            if (!File.Exists(@"C:\\project.json"))
            {
                File.Create(@"C:\\project.json");
            }
            if (!File.Exists(@"C:\\budject.json"))
            {
                File.Create(@"C:\\budject.json");
            }
            if (!File.Exists(@"C:\\resource.json"))
            {
                File.Create(@"C:\\resource.json");
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
