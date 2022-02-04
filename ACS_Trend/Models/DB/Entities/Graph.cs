using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACS_Trend.Models.DB.Entities
{
    public class Graph
    {
        public Graph()
        {

        }

        public int ID_Graph { get; set; }
        public double X_Axe { get; set; }
        public string Y_Axe { get; set; }
    }
}
