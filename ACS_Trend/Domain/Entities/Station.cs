using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS_Trend.Domain.Entities
{
    public class Station
    {
        public Station()
        {
        }

        //[Required]
        [Key]
        public int ID_Station { get; set; }
        public string Station_name { get; set; }       
        public int? ST_ID_Station_type { get; set; }
        [ForeignKey("ST_ID_Station_type")]
        public string ElectricalPower { get; set; }
        public string HeatPower { get; set; }


        public virtual Station_type Station_type { get; set; }

        public virtual ICollection<Trend> Trend { get; set; }
    }
}
