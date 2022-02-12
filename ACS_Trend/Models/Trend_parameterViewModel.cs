using ACS_Trend.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Models
{
    public class Trend_parameterViewModel
    {
        [Key]
        [Display(Name = "Идентификатор параметра тренда")]
        public int ID_Trend_parameter { get; set; }
        [Display(Name = "Наименование параметра тренда")]
        public string Trend_parameter_name { get; set; }
        [Display(Name = "Идентификатор типа параметра тренда")]
        public int TP_ID_Trend_parameter_type { get; set; }
        [Display(Name = "Объект управления")]
        public int TP_ID_Control_object { get; set; }
        [Display(Name = "Тип сигнала")]
        public int TP_ID_Signal_type { get; set; }
        [Display(Name = "Регулятор")]
        public int TP_ID_Regulator { get; set; }


        [Display(Name = "Тип параметра тренда")]
        public Trend_parameter_type Trend_parameter_type { get; set; }
        [Display(Name = "Объект управления")]
        public Control_object Control_object { get; set; }
        [Display(Name = "Тип сигнала")]
        public Signal_type Signal_type { get; set; }
        [Display(Name = "Регулятор")]
        public Regulator Regulator { get; set; }
    }
}
