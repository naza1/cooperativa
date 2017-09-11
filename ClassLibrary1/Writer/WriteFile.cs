using ClassLibrary1.Db;
using FileSystem.Tables;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Cooperativa.FileSystem
{
    public class WriteFile
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

            var jsonData = File.ReadAllText(@"C:\\cooperativa\\project.json");
            var projectList = JsonConvert.DeserializeObject<List<Project>>(jsonData)
                      ?? new List<Project>();

            projectList.Add(project);

            jsonData = JsonConvert.SerializeObject(projectList);

            File.WriteAllText(@"C:\\cooperativa\\project.json", jsonData);
        }

        public void CreateProject(Project project)
        {
            var mongo = new MongoConection();

            mongo.CreateProject(project);
        }

        public void SaveBudjet(Project budject)
        {
            File.WriteAllText(@"C:\\budject.json", JsonConvert.SerializeObject(budject));
        }
        public void SaveResource(Project resource)
        {
            File.WriteAllText(@"C:\\resource.json", JsonConvert.SerializeObject(resource));
        }

        public void SaveStage(Project stage)
        {
            File.WriteAllText(@"C:\\stage.json", JsonConvert.SerializeObject(stage));
        }
    }
}
