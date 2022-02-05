using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS_Trend.Domain.Entities
{
    public class TrendPoint
    {
        public TrendPoint()
        {
        }

        [Required]
        [Key]
        public int ID_TrendPoint { get; set; }
        [ForeignKey("Trend")]
        public int TP_ID_Trend { get; set; }
        public string Date_time { get; set; } // DateTime
        public float Parameter { get; set; }
    }
}
