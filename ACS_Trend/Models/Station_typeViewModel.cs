
using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Models
{
    public class Station_typeViewModel
    {
        [Key]
        public int ID_Station_type { get; set; }
        public string StationType { get; set; }
    }
}
