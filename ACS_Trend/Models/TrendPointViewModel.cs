﻿using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Models
{
    public class TrendPointViewModel
    {
        [Key]
        [Display(Name = "Идентификатор точки графика")]
        public int ID_TrendPoint { get; set; }
        [Display(Name = "Идентификатор тренда")]
        public int TP_ID_Trend { get; set; }
        [Display(Name = "Значение времени")]
        public float Date_time { get; set; } // DateTime
        [Display(Name = "Значение параметра тренда")]
        public float Parameter { get; set; }

        [Display(Name = "Тренд")]
        public TrendViewModel Trend { get; set; }
    }
}