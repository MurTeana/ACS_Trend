using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Models
{
    public class Control_objectViewModel
    {
        [Key]
        [Display(Name = "Идентификатор объекта управления")]
        public int ID_Control_object { get; set; }
        [Display(Name = "Наименование объекта управления")]
        public string Control_object_name { get; set; }
        [Display(Name = "Идентификатор типа объекта управления")]
        public int CO_Control_object_type { get; set; }
        [Display(Name = "Дополнительная информация")]
        public string Extend_information { get; set; }

        [Display(Name = "Тип объекта управления")]
        public Control_object_typeViewModel Control_object_type { get; set; }
    }
}
