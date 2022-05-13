using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS_Trend.Domain.Entities
{
    public class Transient_characteristicPoint
    {
        public Transient_characteristicPoint()
        {
            Date_time = new double();
            Parameter = new double();
        }

        [Required]
        [Key]
        public int ID_Transient_characteristicPoint { get; set; }
        [ForeignKey("Transient_characteristic")]
        public int TPCHP_ID_Transient_characteristic { get; set; }
        public double Date_time { get; set; } // DateTime
        public double Parameter { get; set; }

        public virtual Transient_characteristic Transient_characteristic { get; set; }
    }
}
