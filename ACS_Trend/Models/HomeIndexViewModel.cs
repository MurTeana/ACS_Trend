using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Models
{
    public class HomeIndexViewModel
    {
        public LineChartViewModel LineChartData_IN_Source { get; set; }
        public LineChartViewModel LineChartData_IN_Aproxy { get; set; }
        public LineChartViewModel LineChartData_IN_Tg { get; set; }
        public LineChartViewModel LineChartData_IN_Result { get; set; }

        public LineChartViewModel LineChartData_OUT_Source { get; set; }
        public LineChartViewModel LineChartData_OUT_Aproxy { get; set; }
        public LineChartViewModel LineChartData_OUT_Tg { get; set; }
        public LineChartViewModel LineChartData_OUT_Result { get; set; }

        // дополнительные параметры кнопок
        public string ProcessType { get; set; }

        // дополнительные параметры для анализа

        [Display(Name = "Коэффициент сглаживания")]
        public int K_Approxy { get; set; }

        [Display(Name = "Точка старта")]
        public int StartPoint { get; set; }
    }
}
