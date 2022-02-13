using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS_Trend.Domain.Entities
{
    public class Transient_characteristic
    {
        public Transient_characteristic()
        {
        }

        [Required]
        [Key]
        public int ID_Transient_characteristic { get; set; }
        [ForeignKey("Trend")]
        public int TCH_ID_Trend { get; set; }
        public float Date_time { get; set; } // DateTime
        public float Parameter { get; set; }

        public virtual Trend Trend { get; set; }
    }
}
