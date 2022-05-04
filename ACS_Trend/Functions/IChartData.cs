using ACS_Trend.Models;
using ACS_Trend.Models.Charts;
using System.Collections.Generic;

namespace ACS_Trend.Functions
{
    public interface IChartData
    {
        public LineChartViewModel GetLineChartData(List<LineChartData> chartParam);
    }

    public class ChartData_ : IChartData
    {
        public LineChartViewModel GetLineChartData(List<LineChartData> chartParams)
        {
            var lineChartData = new LineChartViewModel();

            // AXIS
            lineChartData.xAxis.title.text = "Time";
            lineChartData.yAxis.title.text = "Parameter";
            lineChartData.xAxis.crosshair = true;
            lineChartData.yAxis.crosshair = true;

            // PLOTOPTIONS
            lineChartData.plotOptions.line.dataLabels.enabled = false;
            lineChartData.plotOptions.line.enableMouseTracking = true;
            lineChartData.plotOptions.series.lineWidth = 2;
            lineChartData.plotOptions.series.allowPointSelect = true;

            if (chartParams.Count > 0)
            {          
                lineChartData.title.text = chartParams[0].title;
                lineChartData.subtitle.text = chartParams[0].parameter;

                //// PLOTBANDS
                //// PLOTLINES
                lineChartData.xAxis.plotBands = chartParams[0].plotBands;
                lineChartData.xAxis.plotLines = chartParams[0].plotLinesX;
                lineChartData.yAxis.plotLines = chartParams[0].plotLinesY;
            }

            foreach (var item in chartParams)
            {
                // DATA
                var newS = new Series();
                newS.name = item.seriesName;
                newS.data = item.pointsdata;
                newS.color = item.color;
                newS.marker.enabled = item.markerEnable;
                newS.marker.radius = 5;

                lineChartData.series.Add(newS);
            }

            return lineChartData;
        }
    }
}
