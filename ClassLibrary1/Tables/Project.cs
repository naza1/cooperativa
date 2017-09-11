using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace FileSystem.Tables
{
    public class Project
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public int StartBudget { get; set; }

        public int CurrentBudget { get; set; }

        public string Date { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string Status { get; set; }

        public bool Deleted { get; set; }
    }
}
