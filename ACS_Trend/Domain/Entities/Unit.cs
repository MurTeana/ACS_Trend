using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Domain.Entities
{
    public class Unit
    {
        public Unit()
        {
        }

        [Required]
        [Key]
        public int ID_Unit { get; set; }
        public string Unit_name { get; set; }
    }
}
