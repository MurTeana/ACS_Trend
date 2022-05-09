using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS_Trend.Domain.Entities
{
    public class Trend_Transient_characteristic
    {
        public Trend_Transient_characteristic()
        {
        }

        [ForeignKey("Trend")]
        public int TTCH_ID_Trend { get; set; }
        [ForeignKey("Transient_characteristic")]
        public int TTCH_ID_Transient_characteristic { get; set; }

        public virtual Trend Trend { get; set; }
        public virtual Transient_characteristic Transient_characteristic { get; set; }
    }
}
