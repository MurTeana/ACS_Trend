using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS_Trend.Domain.Entities
{
    public class Control_object
    {
        public Control_object()
        {
        }

        [Required]
        [Key]
        public int ID_Control_object { get; set; }
        public string Control_object_name { get; set; }

        [ForeignKey("Control_object_type")]
        public int CO_Control_object_type { get; set; }
        public string Extend_information { get; set; }

        public virtual Control_object_type Control_object_type { get; set; }
        public virtual ICollection<Trend_parameter> Trend_parameter { get; set; }

    }
}
