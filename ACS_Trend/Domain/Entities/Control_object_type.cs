using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Domain.Entities
{
    public class Control_object_type
    {
        public Control_object_type()
        {
        }

        //[Required]
        [Key]
        public int ID_Control_object_type { get; set; }
        public string Control_object_type_name { get; set; }


        public virtual ICollection<Control_object> Control_object { get; set; }
    }
}
