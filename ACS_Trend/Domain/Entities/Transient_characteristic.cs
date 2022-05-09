using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS_Trend.Domain.Entities
{
    public class Transient_characteristic
    {
        public Transient_characteristic()
        {
            Trend_Transient_characteristics = new List<Trend_Transient_characteristic>();
            Transient_characteristicPoints = new List<Transient_characteristicPoint>();
        }

        [Required]
        [Key]
        public int ID_Transient_characteristic { get; set; }

        public virtual ICollection<Trend_Transient_characteristic> Trend_Transient_characteristics { get; set; }
        public virtual ICollection<Transient_characteristicPoint> Transient_characteristicPoints { get; set; }
    }
}
