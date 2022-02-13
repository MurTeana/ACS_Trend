using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Models
{
    public class Transient_characteristicViewModel
    {
        [Key]
        [Display(Name = "Идентификатор переходной характеристики")]
        public int ID_Transient_characteristic { get; set; }
        [Display(Name = "Идентификатор тренда")]
        public int TCH_ID_Trend { get; set; }
        [Display(Name = "Время")]
        public float Date_time { get; set; } // DateTime
        [Display(Name = "Значение параметра")]
        public float Parameter { get; set; }

        [Display(Name = "Тренд")]
        public TrendViewModel Trend { get; set; }
    }
}
