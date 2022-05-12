using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Models
{
    public class HomeIndexViewModel
    {
        public LineChartViewModel LineChartData_IN_Source { get; set; }
        public LineChartViewModel LineChartData_IN_Source_Result { get; set; }
        public LineChartViewModel LineChartData_IN_Aproxy { get; set; }
        public LineChartViewModel LineChartData_IN_Tg { get; set; }
        public LineChartViewModel LineChartData_IN_Result { get; set; }

        public LineChartViewModel LineChartData_OUT_Source { get; set; }
        public LineChartViewModel LineChartData_OUT_Aproxy { get; set; }
        public LineChartViewModel LineChartData_OUT_Tg { get; set; }
        public LineChartViewModel LineChartData_OUT_Result { get; set; }
        public LineChartViewModel LineChartData_TransCh { get; set; }

        //
        public TrendPointViewModel TrendPointViewModel_ { get; set; }
        public Transient_characteristicPointViewModel Transient_characteristicPointViewModel_ { get; set; }

        // дополнительные параметры кнопок
        public string ProcessType { get; set; }

        // дополнительные параметры для анализа

        [Display(Name = "Точка старта")]
        public int StartPoint { get; set; } = 1843;
        [Display(Name = "Коэффициент смещения")]
        public double K_Moving { get; set; } = 0.6;

        [Display(Name = "Параметр зоны нечувствительности графика тренда входного сигнала")]
        public double ToleranceZone_K_IN { get; set; } = 0.015;

        [Display(Name = "Параметр зоны нечувствительности графика тренда выходного сигнала")]
        public double ToleranceZone_K_OUT { get; set; } = 0.015;

        [Display(Name = "Верхнее ограничение точек тренда входного сигнала")]
        public double UpperLimit_IN { get; set; } = 17;

        [Display(Name = "Верхнее ограничение точек тренда выходного сигнала")]
        public double UpperLimit_OUT { get; set; } = 950;

        [Display(Name = "Нижнее ограничение точек тренда входного сигнала")]
        public double LowerLimit_IN { get; set; } = 4.5;

        [Display(Name = "Нижнее ограничение точек тренда выходного сигнала")]
        public double LowerLimit_OUT { get; set; } = 256;

        [Display(Name = "Ограничение по времени тренда входного сигнала")]
        public int TimeLimit_IN { get; set; } = 50;

        [Display(Name = "Ограничение по времени тренда выходного сигнала")]
        public int TimeLimit_OUT { get; set; } = 50;
        [Display(Name = "Коэффициент сглаживания графика тренда входного сигнала")]
        public int K_Approxy_IN { get; set; } = 40;

        [Display(Name = "Коэффициент сглаживания графика тренда выходного сигнала")]
        public int K_Approxy_OUT { get; set; } = 40;



    }
}
