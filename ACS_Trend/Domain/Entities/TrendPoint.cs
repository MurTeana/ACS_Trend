using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS_Trend.Domain.Entities
{
    public class TrendPoint
    {
        public TrendPoint()
        {
            Date_time = new double();
            Parameter = new double();
        }

        [Required]
        [Key]
        public int ID_TrendPoint { get; set; }
        [ForeignKey("Trend")]
        public int TP_ID_Trend { get; set; }
        public double Date_time { get; set; } // DateTime
        public double Parameter { get; set; }


        public virtual Trend Trend { get; set; }
    }
}
