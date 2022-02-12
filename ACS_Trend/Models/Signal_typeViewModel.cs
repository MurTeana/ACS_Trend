using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Models
{
    public class Signal_typeViewModel
    {
        [Key]
        [Display(Name = "Идентификатор типа сигнала")]
        public int ID_Trend_signal_type { get; set; }
        [Display(Name = "Тип сигнала")]
        public string Signal_type_name { get; set; }
    }
}
