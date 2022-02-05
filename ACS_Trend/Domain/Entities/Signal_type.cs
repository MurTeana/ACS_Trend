using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Domain.Entities
{
    public class Signal_type
    {
        public Signal_type()
        {
        }

        [Required]
        [Key]
        public int ID_Trend_signal_type { get; set; }
        public string Signal_type_name { get; set; }
    }

}
