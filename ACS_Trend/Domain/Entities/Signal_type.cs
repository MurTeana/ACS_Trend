using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Domain.Entities
{
    public class Signal_type
    {
        public Signal_type()
        {
        }

        [Required]
        [Key]
        [Display(Name = "Идентификатор типа сигнала")]
        public int ID_Signal_type { get; set; }
        [Display(Name = "Тип сигнала")]
        public string Signal_type_name { get; set; }

        [Display(Name = "Тренды")]
        public virtual ICollection<Trend> Trends { get; set; }

    }

}
