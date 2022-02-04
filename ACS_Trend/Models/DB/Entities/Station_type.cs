using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Models.DB.Entities
{
    public class Station_type
    {
        public Station_type()
        {
        }

        [Required]
        [Key]
        public int ID_Station_type { get; set; }
        public string StationType { get; set; }
    }
}
