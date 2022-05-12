using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Domain.Entities
{
    public class Trend_parameter_name
    {
        public Trend_parameter_name()
        {
        }

        [Required]
        [Key]
        [Display(Name = "Идентификатор наименования параметра тренда")]
        public int ID_Trend_parameter_name { get; set; }
        [Display(Name =  "Наименование параметра тренда")]
        public string Trend_parameter_name_val { get; set; }

        [Display(Name = "Параметры трендов")]
        public virtual ICollection<Trend> Trends { get; set; }

    }

}
