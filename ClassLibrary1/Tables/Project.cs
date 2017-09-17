using System;

namespace FileSystem.Tables
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal StartBudget { get; set; }

        public decimal CurrentBudget { get; set; }

        public string CreationDate { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string Status { get; set; }

        public string Deleted { get; set; }
    }
}
