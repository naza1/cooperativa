using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem.Tables
{
    public class Budget
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public Decimal Amount { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }
    }
}
