using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Domain.Entities
{
    public class Regulator
    {
        public Regulator()
        {
        }

        [Required]
        [Key]
        [Display(Name = "Идентификатор регулятора")]
        public int ID_Regulator { get; set; }
        [Display(Name = "Наименование регулятора")]
        public string Regulator_name { get; set; }

        [Display(Name = "Параметры тренда")]
        public virtual ICollection<Trend_parameter> Trend_parameter { get; set; }
    }
}
