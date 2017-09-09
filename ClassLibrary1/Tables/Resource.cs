using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem.tablas
{
    public class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }

        public decimal Price { get; set; }

        public int StageId { get; set; }

        public int CompanyId { get; set; }

        public DateTime StartDate { get; set; }
    }
}
