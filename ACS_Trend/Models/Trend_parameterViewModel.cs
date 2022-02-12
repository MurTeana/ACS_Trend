using ACS_Trend.Domain.Entities;

namespace ACS_Trend.Models
{
    public class Trend_parameterViewModel
    {
        public int ID_Trend_parameter { get; set; }
        public string Trend_parameter_name { get; set; }
        public int TP_ID_Trend_parameter_type { get; set; }
        public int TP_ID_Control_object { get; set; }
        public int TP_ID_Signal_type { get; set; }
        public int TP_ID_Regulator { get; set; }


        public Trend_parameter_type Trend_parameter_type { get; set; }
        public Control_object Control_object { get; set; }
        public Signal_type Signal_type { get; set; }
        public Regulator Regulator { get; set; }
    }
}
