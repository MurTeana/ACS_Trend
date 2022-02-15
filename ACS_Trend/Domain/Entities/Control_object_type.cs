using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Domain.Entities
{
    public class Control_object_type
    {
        public Control_object_type()
        {
        }

        //[Required]
        [Key]
        [Display(Name = "Идентификатор типа объекта управления")]
        public int ID_Control_object_type { get; set; }
        [Display(Name = "Тип объекта управления")]
        public string Control_object_type_name { get; set; }

        [Display(Name = "Объект управления")]
        public virtual ICollection<Control_object> Control_object { get; set; }
    }
}
