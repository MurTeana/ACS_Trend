using System.Collections.Generic;
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
        [Display(Name = "Идентификатор единицы измерения")]
        public int ID_Unit { get; set; }
        [Display(Name = "Единица измерения")]
        public string Unit_name { get; set; }

        [Display(Name = "Тренды")]
        public virtual ICollection<Trend> Trend { get; set; }
    }
}
