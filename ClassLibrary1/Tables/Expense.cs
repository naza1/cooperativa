using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem.tablas
{
    public class Expense
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public decimal Amount { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public int VoucherNumber { get; set; }

        public string Date { get; set; }

        public string Description { get; set; }

        public string Deleted { get; set; }
    }
}