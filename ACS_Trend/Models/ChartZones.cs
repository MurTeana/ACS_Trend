using System.Collections.Generic;

namespace ACS_Trend.Models
{
    public class ChartZones
    {
        public ChartZones(List<PlotBands> v1, List<PlotLines> v2, List<int> v3)
        {
            plotbands = v1;
            plotlines = v2;
            pointFindAll = v3;
        }
        public List<PlotBands> plotbands { get; set; }
        public List<PlotLines> plotlines { get; set; }
        public List<int> pointFindAll { get; set; }
    }
}
