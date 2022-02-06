using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS_Trend.Domain.Entities
{
    public class Station
    {
        public Station()
        {
        }

        [Required]
        [Key]
        public int ID_Station { get; set; }
        public string Station_name { get; set; }
        [ForeignKey("Station_type")]
        public int ST_ID_Station_type { get; set; }
        public string ElectricalPower { get; set; }
        public string HeatPower { get; set; }
    }
}