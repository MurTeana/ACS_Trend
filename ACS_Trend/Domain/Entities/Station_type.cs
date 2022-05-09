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
        [Display(Name = "Идентификатор типа станции")]
        public int ID_Station_type { get; set; }
        [Display(Name = "Тип станции")]
        public string Station_type_name { get; set; }

        [Display(Name = "Станции")]
        public virtual ICollection<Station> Stations { get; set; }
    }
}
