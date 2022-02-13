using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Models
{
    public class Station_typeViewModel
    {
        [Key]
        [Display(Name = "Идентификатор типа станции")]
        public int ID_Station_type { get; set; }
        [Display(Name = "Тип станции")]
        public string Station_type_name { get; set; }
    }
}
