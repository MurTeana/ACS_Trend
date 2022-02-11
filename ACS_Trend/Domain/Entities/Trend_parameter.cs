using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS_Trend.Domain.Entities
{
    public class Trend_parameter
    {
        public Trend_parameter()
        {
        }

        [Required]
        [Key]
        public int ID_Trend_parameter { get; set; }
        public string Trend_parameter_name { get; set; }
        [ForeignKey("Trend_parameter_type")]
        public int TP_ID_Trend_parameter_type { get; set; }
        [ForeignKey("Control_object")]
        public int TP_ID_Control_object { get; set; }
        [ForeignKey("Signal_type")]
        public int TP_ID_Signal_type { get; set; }
        [ForeignKey("Regulator")]
        public int TP_ID_Regulator { get; set; }


        public virtual ICollection<Trend> Trend { get; set; }
        public virtual Trend_parameter_type Trend_parameter_type { get; set; }
        public virtual Control_object Control_object { get; set; }
        public virtual Signal_type Signal_type { get; set; }
        public virtual Regulator Regulator { get; set; }
    }
}
