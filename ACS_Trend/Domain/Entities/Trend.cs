using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS_Trend.Domain.Entities
{
    public class Trend
    {
        public Trend()
        {
            Trend_Transient_characteristics = new List<Trend_Transient_characteristic>();
            TrendPoints = new List<TrendPoint>();
        }

        [Required]
        [Key]
        [Display(Name = "Идентификатор тренда")]
        public int ID_Trend { get; set; }
        [ForeignKey("Station")]
        [Display(Name = "Станция")]
        public int T_ID_Station { get; set; }
        [ForeignKey("Trend_parameter")]
        [Display(Name = "Параметр тренда")]
        public int T_ID_Trend_parameter { get; set; }
        [ForeignKey("Unit")]
        [Display(Name = "Единица измерения")]
        public int T_ID_Unit { get; set; }


        public virtual ICollection<TrendPoint> TrendPoints { get; set; }
        public virtual ICollection<Trend_Transient_characteristic> Trend_Transient_characteristics { get; set; }
        public virtual Station Station { get; set; }
        public virtual Trend_parameter Trend_parameter { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
