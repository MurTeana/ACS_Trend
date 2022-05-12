using ACS_Trend.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Models
{
    public class TrendPointViewModel
    {
        [Key]
        [Display(Name = "Идентификатор точки графика")]
        public int ID_TrendPoint { get; set; }
        [Display(Name = "Идентификатор тренда")]
        public int TP_ID_Trend { get; set; }
        [Display(Name = "Значение времени")]
        public double Date_time { get; set; } // DateTime
        [Display(Name = "Значение параметра тренда")]
        public double Parameter { get; set; }

        // ТРЕНД
        [Display(Name = "Станция")]
        public string  TP_Station { get; set; }
        [Display(Name = "Идентификатор параметра тренда")]
        public string TP_Trend_parameter { get; set; }
        [Display(Name = "Идентификатор единицы измерения")]
        public string TP_Unit { get; set; }

        public Trend Trend { get; set; }
    }
}
