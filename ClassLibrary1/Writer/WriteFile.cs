using ClassLibrary1.Db;
using FileSystem.Tables;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace Cooperativa.FileSystem
{
    public class WriteFile
    {
        private SQLiteConnection _dbConnection;

        public WriteFile()
        {
            SQLiteConnection.CreateFile("cooperativa.db3");

        }

        public void CreateProject(Project project)
        {   
            _dbConnection = new SQLiteConnection("Data Source=cooperativa.db3");

            _dbConnection.Open();

            string sql = "create table Project (id int, name varchar(20))";

            var command = new SQLiteCommand(sql, _dbConnection);

            command.ExecuteNonQuery();

            _dbConnection.Close();
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
