using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS_Trend.Domain.Entities
{
    public class Trend
    {
        public Trend()
        {
            Trend_Transient_characteristics = new List<Trend_Transient_characteristic>();
            TrendPoints = new List<TrendPoint>();
        }

        [Required]
        [Key]
        [Display(Name = "Идентификатор тренда")]
        public int ID_Trend { get; set; }

        [ForeignKey("Station")]
        [Display(Name = "Станция")]
        public int T_ID_Station { get; set; }

        [ForeignKey("Unit")]
        [Display(Name = "Единица измерения")]
        public int T_ID_Unit { get; set; }

        [ForeignKey("Trend_parameter_name")]
        [Display(Name = "Наименование параметра тренда")]
        public int T_ID_Trend_parameter_name { get; set; }

        [ForeignKey("Control_object")]
        [Display(Name = "Объект управления")]
        public int T_ID_Control_object { get; set; }

        [ForeignKey("Signal_type")]
        [Display(Name = "Тип сигнала")]
        public int T_ID_Signal_type { get; set; }

        [ForeignKey("Regulator")]
        [Display(Name = "Регулятор")]
        public int T_ID_Regulator { get; set; }



        public virtual ICollection<TrendPoint> TrendPoints { get; set; }
        public virtual ICollection<Trend_Transient_characteristic> Trend_Transient_characteristics { get; set; }


        [Display(Name = "Наименование параметра")]
        public virtual Trend_parameter_name Trend_parameter_name { get; set; }

        [Display(Name = "Станция")]
        public virtual Station Station { get; set; }

        [Display(Name = "Единица измерения")]
        public virtual Unit Unit { get; set; }

        [Display(Name = "Объект управления")]
        public virtual Control_object Control_object { get; set; }

        [Display(Name = "Тип сигнала")]
        public virtual Signal_type Signal_type { get; set; }

        [Display(Name = "Регулятор")]
        public virtual Regulator Regulator { get; set; }
    }
}
