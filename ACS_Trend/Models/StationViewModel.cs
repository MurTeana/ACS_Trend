using ACS_Trend.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Models
{
    public class StationViewModel
    {
        [Key]
        public int ID_Station { get; set; }
        public string Station_name { get; set; }
        public int? ST_ID_Station_type { get; set; }
        public string ElectricalPower { get; set; }
        public string HeatPower { get; set; }

        public Station_typeViewModel Station_Type { get; set; }
    }
}
