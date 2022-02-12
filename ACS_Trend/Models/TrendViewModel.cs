using ACS_Trend.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Models
{
    public class TrendViewModel
    {
        [Key]
        public int ID_Trend { get; set; }
        public int T_ID_Station { get; set; }
        public int T_ID_Trend_parameter { get; set; }
        public int T_ID_Unit { get; set; }

        public Station Station { get; set; }
        public Trend_parameter Trend_parameter { get; set; }
        public Unit Unit { get; set; }
    }
}
