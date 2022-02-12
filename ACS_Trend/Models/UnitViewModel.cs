using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Models
{
    public class UnitViewModel
    {
        [Key]
        public int ID_Unit { get; set; }
        public string Unit_name { get; set; }
    }
}
