using ACS_Trend.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Models
{
    public class StationViewModel
    {
        [Key]
        [Display(Name = "Идентификатор станции")]
        public int ID_Station { get; set; }

        [Display(Name = "Наименование станции")]
        public string Station_name { get; set; }
        [Display(Name = "ID Тип станции")]
        public int? ST_ID_Station_type { get; set; }
        [Display(Name = "Электрическая мощность")]
        public string ElectricalPower { get; set; }
        [Display(Name = "Тепловая мощность")]
        public string HeatPower { get; set; }

        [Display(Name = "Тип станции")]
        public Station_type Station_Type { get; set; }
    }
}
