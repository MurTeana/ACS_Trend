using ACS_Trend.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Models
{
    public class Transient_characteristicPointViewModel
    {
        [Key]
        [Display(Name = "Идентификатор точки графика")]
        public int ID_Transient_characteristicPoint { get; set; }
        [Display(Name = "Идентификатор переходной характеристики")]
        public int TPCHP_ID_Transient_characteristic { get; set; }

        [Display(Name = "Значение времени")]
        public double Date_time { get; set; } // DateTime

        [Display(Name = "Значение параметра тренда")]
        public double Parameter { get; set; }

        // ПЕРЕХОДНАЯ ХАРАКТЕРИСТИКА
        public Transient_characteristic Transient_characteristic { get; set; }
        public Trend TrendIN { get; set; }
        public Trend TrendOUT { get; set; }

        // ТОЧКИ
        public List<TrendPoint> pointsIN { get; set; }
        public List<TrendPoint> pointsOUT { get; set; }
        public List<Transient_characteristicPoint> trCharpoints  { get; set; } 
    }
}
