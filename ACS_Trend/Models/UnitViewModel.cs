using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Models
{
    public class UnitViewModel
    {
        [Key]
        [Display(Name = "Идентификатор единицы измерения")]
        public int ID_Unit { get; set; }
        [Display(Name = "Единица измерения")]
        public string Unit_name { get; set; }
    }
}
