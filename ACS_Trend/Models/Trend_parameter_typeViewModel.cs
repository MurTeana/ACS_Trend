using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Models
{
    public class Trend_parameter_typeViewModel
    {
        [Key]
        public int ID_Trend_parameter_type { get; set; }
        public string Trend_parameter_type_name { get; set; }
    }
}
