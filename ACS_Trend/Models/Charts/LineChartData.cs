using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACS_Trend.Models.Charts
{
    public class LineChartData
    {
        public List<double[]> pointsdata { get; set; }
        public string title { get; set; }
        public string parameter { get; set; }
        public string seriesName { get; set; }
        public string color { get; set; }
        public bool markerEnable { get; set; }
        public List<PlotBands> plotBands { get; set; }
        public List<PlotLines> plotLinesX { get; set; }
        public List<PlotLines> plotLinesY { get; set; }
    }
}
