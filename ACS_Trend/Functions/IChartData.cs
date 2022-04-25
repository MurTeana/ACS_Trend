using ACS_Trend.Models;
using System.Collections.Generic;

namespace ACS_Trend.Functions
{
    public interface IChartData
    {
        public LineChartViewModel GetLineChartData(
            List<double[]> pointsdata,
            string title,
            string parameter,
            string seriesName,
            string color,
            bool markerEnable,
            List<PlotBands> plotBands,
            List<PlotLines> plotLinesX,
            List<PlotLines> plotLinesY);
    }

    public class ChartData_ : IChartData
    {
        public LineChartViewModel GetLineChartData(
            List<double[]> pointsdata,
            string title,
            string parameter,
            string seriesName,
            string color,
            bool markerEnable,
            List<PlotBands> plotBands,
            List<PlotLines> plotLinesX,
            List<PlotLines> plotLinesY)
        {
            var lineChartData = new LineChartViewModel();

            lineChartData.title.text = title;
            lineChartData.subtitle.text = parameter;

            // AXIS
            lineChartData.xAxis.title.text = "Time";
            lineChartData.yAxis.title.text = "Parameter";
            lineChartData.xAxis.crosshair = true;
            lineChartData.yAxis.crosshair = true;

            //// PLOTBANDS
            //// PLOTLINES
            lineChartData.xAxis.plotBands = plotBands;
            lineChartData.xAxis.plotLines = plotLinesX;
            lineChartData.yAxis.plotLines = plotLinesY;

            // PLOTOPTIONS
            lineChartData.plotOptions.line.dataLabels.enabled = false;
            lineChartData.plotOptions.line.enableMouseTracking = true;
            lineChartData.plotOptions.series.lineWidth = 2; 
            lineChartData.plotOptions.series.allowPointSelect = true;

            // DATA
            lineChartData.series.name = seriesName;
            lineChartData.series.data = pointsdata;
            lineChartData.series.color = color;
            lineChartData.series.marker.enabled = markerEnable;
            lineChartData.series.marker.radius = 5;

            return lineChartData;
        }
    }
}
