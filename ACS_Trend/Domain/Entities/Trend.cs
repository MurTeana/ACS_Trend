using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS_Trend.Domain.Entities
{
    public class Trend
    {
        public Trend()
        {
        }

        [Required]
        [Key]
        public int ID_Trend { get; set; }
        [ForeignKey("Station")]
        public int T_ID_Station { get; set; }
        [ForeignKey("Trend_parameter")]
        public int T_ID_Trend_parameter { get; set; }
        [ForeignKey("Unit")]
        public int T_ID_Unit { get; set; }
    }
}
