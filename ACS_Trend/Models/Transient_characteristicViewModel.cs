using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ACS_Trend.Models
{
    public class Transient_characteristicViewModel
    {
        [Key]
        public int ID_Transient_characteristic { get; set; }
        public int TCH_ID_Trend { get; set; }
        public string Date_time { get; set; } // DateTime
    }
}
