using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Domain.Entities
{
    public class Trend_parameter_type
    {
        public Trend_parameter_type()
        {
        }

        [Required]
        [Key]
        public int ID_Trend_parameter_type { get; set; }
        public string Trend_parameter_type_name { get; set; }
    }
}