
using System.Collections.Generic;

namespace ACS_Trend.Models.Charts
{
    public class ChartsParameters
    {
        public LineChartData LineChartData_Default { get; set; } = new LineChartData
        {
            pointsdata = new List<double[]>(),
            title = "",
            parameter = "",
            seriesName = "",
            color = "#4682B4",
            markerEnable = false,
            plotBands = null,
            plotLinesX = null,
            plotLinesY = null
        };

        public LineChartData LineChartData_IN_Source { get; set; } = new LineChartData
        {
            pointsdata = new List<double[]>(),
            title = "Тренд динамических характеристик входного сигнала теплоэнергетичеcкого оборудования",
            parameter = "",
            seriesName = "Точки тренда входного сигнала",
            color = "#4682B4",
            markerEnable = false,
            plotBands = null,
            plotLinesX = null,
            plotLinesY = null
        };
        public LineChartData LineChartData_IN_MovAver { get; set; } = new LineChartData
        {
            pointsdata = new List<double[]>(),
            title = "Сглаженные значения тренда динамических характеристик входного сигнала теплоэнергетичеcкого оборудования",
            parameter = "",
            seriesName = "Точки сглаженных значений тренда входного сигнала",
            color = "#4682B4",
            markerEnable = false,
            plotBands = null,
            plotLinesX = null,
            plotLinesY = null
        };
        public LineChartData LineChartData_IN_DerF { get; set; } = new LineChartData
        {
            pointsdata = new List<double[]>(),
            title = "Производные сглаженных значений тренда динамических характеристик входного сигнала теплоэнергетичеcкого оборудования",
            parameter = "",
            seriesName = "Точки производных графика тренда",
            color = "#4682B4",
            markerEnable = false,
            plotBands = null,
            plotLinesX = null,
            plotLinesY = null
        };
        public LineChartData LineChartData_IN_Result { get; set; } = new LineChartData
        {
            pointsdata = new List<double[]>(),
            title = "",
            parameter = "",
            seriesName = "Точки перелома графика тренда",
            color = "rgba(255,99,71,.5)",
            markerEnable = true,
            plotBands = null,
            plotLinesX = null,
            plotLinesY = null
        };

        public LineChartData LineChartData_OUT_Source { get; set; } = new LineChartData
        {
            pointsdata = new List<double[]>(),
            title = "Тренд динамических характеристик выходного сигнала теплоэнергетичеcкого оборудования",
            parameter = "",
            seriesName = "Точки тренда выходного сигнала",
            color = "#4682B4",
            markerEnable = false,
            plotBands = null,
            plotLinesX = null,
            plotLinesY = null
        };
        public LineChartData LineChartData_OUT_MovAver { get; set; } = new LineChartData
        {
            pointsdata = new List<double[]>(),
            title = "Сглаженные значения тренда динамических характеристик выходного сигнала теплоэнергетичеcкого оборудования",
            parameter = "",
            seriesName = "Точки сглаженных значений тренда выходного сигнала",
            color = "#4682B4",
            markerEnable = false,
            plotBands = null,
            plotLinesX = null,
            plotLinesY = null
        };
        public LineChartData LineChartData_OUT_DerF { get; set; } = new LineChartData
        {
            pointsdata = new List<double[]>(),
            title = "Производные сглаженных значений тренда динамических характеристик выходного сигнала теплоэнергетичеcкого оборудования",
            parameter = "",
            seriesName = "Точки производных графика тренда",
            color = "#4682B4",
            markerEnable = false,
            plotBands = null,
            plotLinesX = null,
            plotLinesY = null
        };
        public LineChartData LineChartData_OUT_Result { get; set; } = new LineChartData
        {
            pointsdata = new List<double[]>(),
            title = "",
            parameter = "",
            seriesName = "Точки перелома графика тренда",
            color = "rgba(255,99,71,.5)",
            markerEnable = true,
            plotBands = null,
            plotLinesX = null,
            plotLinesY = null
        };

        public LineChartData LineChartData_TransCh { get; set; } = new LineChartData
        {
            pointsdata = new List<double[]>(),
            title = "Переходные характеристики теплоэнергетического оборудования",
            parameter = "",
            seriesName = "Переходная характеристика",
            color = "#4682B4",
            markerEnable = false,
            plotBands = null,
            plotLinesX = null,
            plotLinesY = null
        };
    }
}
