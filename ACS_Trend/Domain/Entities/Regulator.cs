using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Domain.Entities
{
    public class Regulator
    {
        public Regulator()
        {
        }

        [Required]
        [Key]
        public int ID_Regulator { get; set; }
        public string Regulator_name { get; set; }


        public virtual ICollection<Trend_parameter> Trend_parameter { get; set; }
    }
}
