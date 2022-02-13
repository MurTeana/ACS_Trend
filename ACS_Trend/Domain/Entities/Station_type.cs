using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Domain.Entities
{
    public class Station_type
    {
        public Station_type()
        {
        }

        //[Required]
        [Key]
        public int ID_Station_type { get; set; }
        public string Station_type_name { get; set; }


        public virtual ICollection<Station> Station { get; set; }
    }
}
