using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Domain.Entities
{
    public class Trend_parameter_type
    {
        public Trend_parameter_type()
        {
        }

        [Required]
        [Key]
        [Display(Name = "Идентификатор типа параметра тренда")]
        public int ID_Trend_parameter_type { get; set; }
        [Display(Name = "Тип параметра тренда")]
        public string Trend_parameter_type_name { get; set; }

        [Display(Name = "Параметры тренда")]
        public virtual ICollection<Trend_parameter> Trend_parameter { get; set; }
    }
}