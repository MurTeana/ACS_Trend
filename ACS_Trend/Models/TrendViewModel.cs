using ACS_Trend.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Models
{
    public class TrendViewModel
    {
        [Key]
        [Display(Name = "Идентификатор тренда")]
        public int ID_Trend { get; set; }
        [Display(Name = "Идентификатор станции")]
        public int T_ID_Station { get; set; }
        [Display(Name = "Идентификатор параметра тренда")]
        public int T_ID_Trend_parameter { get; set; }
        [Display(Name = "Идентификатор единицы измерения")]
        public int T_ID_Unit { get; set; }

        [Display(Name = "Станция")]
        public StationViewModel Station { get; set; }
        [Display(Name = "Параметр тренда")]
        public Trend_parameterViewModel Trend_parameter { get; set; }
        [Display(Name = "Единица измерения")]
        public Unit Unit { get; set; }
    }
}
