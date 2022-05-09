using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS_Trend.Domain.Entities
{
    public class Control_object
    {
        public Control_object()
        {
        }

        //[Required]
        [Key]
        [Display(Name = "Идентификатор объекта управления")]
        public int ID_Control_object { get; set; }
        [Display(Name = "Наименование объекта управления")]
        public string Control_object_name { get; set; }
        [Display(Name = "Идентификатор типа объекта управления")]
        [ForeignKey("Control_object_type")]
        public int CO_ID_Control_object_type { get; set; }
        [Display(Name = "Дополнительная информация")]
        public string Extend_information { get; set; }

        [Display(Name = "Тип объекта управления")]
        public virtual Control_object_type Control_object_type { get; set; }
        [Display(Name = "Параметры трендов")]
        public virtual ICollection<Trend_parameter> Trend_parameters { get; set; }

    }
}
