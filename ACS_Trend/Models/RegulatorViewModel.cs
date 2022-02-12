using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Models
{
    public class RegulatorViewModel
    {
        [Key]
        [Display(Name = "Идентификатор регулятора")]
        public int ID_Regulator { get; set; }
        [Display(Name = "Наименование регулятора")]
        public string Regulator_name { get; set; }
    }
}
