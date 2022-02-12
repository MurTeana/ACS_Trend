using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Models
{
    public class Trend_parameter_typeViewModel
    {
        [Key]
        [Display(Name = "Идентификатор типа параметра тренда")]
        public int ID_Trend_parameter_type { get; set; }
        [Display(Name = "Тип параметра тренда")]
        public string Trend_parameter_type_name { get; set; }
    }
}
