using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem.Tables
{
    public class Stage
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int ProjectId { get; set; }

    }
}
