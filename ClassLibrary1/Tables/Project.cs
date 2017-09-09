using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem.Tables
{
    public class Project
    {
        public int Id { get; set; }

        public decimal BudgetStart { get; set; }

        public decimal BudgetCurrent { get; set; }

        public string Status { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool Deleted { get; set; }

    }
}
