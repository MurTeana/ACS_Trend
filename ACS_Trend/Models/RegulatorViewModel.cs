using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Models
{
    public class RegulatorViewModel
    {
        [Key]
        public int ID_Regulator { get; set; }
        public string Regulator_name { get; set; }
    }
}
