using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACS_Trend.Models
{
    public class TestLoadCSV
    {
        [Index(0)]
        public string Date { get; set; } = "";
        [Index(1)]
        public string Parameter { get; set; } = "";
    }
}
