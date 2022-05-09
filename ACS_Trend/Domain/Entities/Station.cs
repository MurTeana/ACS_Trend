using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS_Trend.Domain.Entities
{
    public class Station
    {
        public Station()
        {
        }

        //[Required]
        [Key]
        [Display(Name = "Идентификатор станции")]
        public int ID_Station { get; set; }
        [Display(Name = "Наименование станции")]
        public string Station_name { get; set; }
        [Display(Name = "ID Тип станции")]
        [ForeignKey("ST_ID_Station_type")]
        public int? ST_ID_Station_type { get; set; }
        [Display(Name = "Электрическая мощность")]
        public string ElectricalPower { get; set; }
        [Display(Name = "Тепловая мощность")]
        public string HeatPower { get; set; }


        [Display(Name = "Тип станции")]
        public virtual Station_type Station_type { get; set; }
        [Display(Name = "Тренды")]
        public virtual ICollection<Trend> Trends { get; set; }
    }
}
