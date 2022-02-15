using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS_Trend.Domain.Entities
{
    public class Trend_parameter
    {
        public Trend_parameter()
        {
        }

        [Required]
        [Key]
        [Display(Name = "Идентификатор параметра тренда")]
        public int ID_Trend_parameter { get; set; }
        [Display(Name = "Наименование параметра тренда")]
        public string Trend_parameter_name { get; set; }
        [ForeignKey("Trend_parameter_type")]
        [Display(Name = "Идентификатор типа параметра тренда")]
        public int TP_ID_Trend_parameter_type { get; set; }
        [ForeignKey("Control_object")]
        [Display(Name = "Объект управления")]
        public int TP_ID_Control_object { get; set; }
        [ForeignKey("Signal_type")]
        [Display(Name = "Тип сигнала")]
        public int TP_ID_Signal_type { get; set; }
        [ForeignKey("Regulator")]
        [Display(Name = "Регулятор")]
        public int TP_ID_Regulator { get; set; }


        public virtual ICollection<Trend> Trend { get; set; }
        [Display(Name = "Тип параметра тренда")]
        public virtual Trend_parameter_type Trend_parameter_type { get; set; }
        [Display(Name = "Объект управления")]
        public virtual Control_object Control_object { get; set; }
        [Display(Name = "Тип сигнала")]
        public virtual Signal_type Signal_type { get; set; }
        [Display(Name = "Регулятор")]
        public virtual Regulator Regulator { get; set; }
    }
}
