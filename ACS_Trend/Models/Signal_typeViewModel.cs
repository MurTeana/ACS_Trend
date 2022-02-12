using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Models
{
    public class Signal_typeViewModel
    {
        [Key]
        public int ID_Trend_signal_type { get; set; }
        public string Signal_type_name { get; set; }
    }
}
