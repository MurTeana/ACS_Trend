using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Models
{
    public class Control_object_typeViewModel
    {
        [Key]
        [Display(Name = "Идентификатор типа объекта управления")]
        public int ID_Control_object_type { get; set; }
        [Display(Name = "Тип объекта управления")]
        public string Control_object_type_name { get; set; }
    }
}
