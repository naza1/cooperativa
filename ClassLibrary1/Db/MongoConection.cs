using FileSystem.Tables;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1.Db
{
    public class MongoConection
    {
        private IMongoDatabase _db;
        public MongoConection()
        {
            var mongo = new MongoClient("mongodb://localhost");
            _db = mongo.GetDatabase("cooperativa");
        }

        public void CreateProject(Project project)
        {
            var collection = _db.GetCollection<Project>("Project");

            collection.InsertOne(project);
        }

        public List<Project> GetProjects()
        {
            var collection = _db.GetCollection<Project>("Project");

            return collection.Find(_ => true).ToList();
        }
    }
}
